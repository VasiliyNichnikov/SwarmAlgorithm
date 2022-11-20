using System;
using System.Linq;
using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public class Particle
    {
        private Vector2 _localBestSolution;
        
        private Vector2 _position;
        private Vector2 _velocity;
        private ISwarm _swarm;

        public Particle(ISwarm swarm)
        {
            _position = InitStartPosition(swarm);
            _velocity = Vector2.RandomFromZeroToOne;
            _localBestSolution = Vector2.Zero;
        }

        private Vector2 InitStartPosition(ISwarm swarm)
        {
            var different = swarm.MaxValues.Except(swarm.MinValues).ToArray();
            var added = different.Concat(swarm.MinValues).ToArray();
            return Vector2.RandomFromZeroToOne * added; 
        }

        private Vector2 InitStartVelocity(ISwarm swarm)
        {
            float[] minValues = swarm.MaxValues.Except(swarm.MinValues).ToArray();
            float[] maxValues = new float[minValues.Length];
            Array.Copy(minValues, maxValues, minValues.Length);
            
            for (int i = 0; i < minValues.Length; i++)
            {
                minValues[i] = -minValues[i];
            }

            var different = maxValues.Except(minValues).ToArray();
            var added = different.Concat(minValues).ToArray();
            
            return Vector2.RandomFromZeroToOne * added;
        }

        public void Correction()
        {
            var weightRatioP = 0.0f; // todo эти значения нужно булет задавать ручками)
            var weightRatioG = 0.0f; // todo эти значения нужно булет задавать ручками)
            var r1 = RandomWrap.NextFloat(); // todo нужно убедиться что число от нуля до единицы
            var r2 = RandomWrap.NextFloat(); // todo нужно убедиться что число от нуля до единицы

            var newVelocity = _velocity + weightRatioP * r1 * (_localBestSolution - _position) + 
                              weightRatioG * r2 * (_swarm.GlobalBestSolution - _position);
            var newPosition = _position + newVelocity;

            _velocity = newVelocity;
            _position = newPosition;
        }
    }
}