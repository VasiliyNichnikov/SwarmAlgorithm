using System;
using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public class Swarm : ISwarm
    {
        public float[] MinValues { get; }
        public float[] MaxValues { get; }
        public float[] GlobalBestSolutionPosition { get; private set; }
        public float GlobalBestSolutionFunc { get; private set; }
        public int Dimension { get; private set; }
        public float WeightRatioP { get; }
        public float WeightRatioG { get; }

        private readonly int _swarmSize;
        private Particle[,] _particles;

        public Swarm(
            int swarmSize,
            int dimension,
            float[] minValues,
            float[] maxValues,
            float weightRatioP,
            float weightRatioG)
        {
            _swarmSize = swarmSize;
            MinValues = minValues;
            MaxValues = maxValues;
            
            WeightRatioP = weightRatioP;
            WeightRatioG = weightRatioG;
            Dimension = dimension;
            
            GlobalBestSolutionFunc = 200000.0f;
            GlobalBestSolutionPosition = FloatArrayExtensions.Zero(dimension);

            InitSwarm();
        }

        private void InitSwarm()
        {
            _particles = new Particle[_swarmSize, _swarmSize];
            for (int i = 0; i < _swarmSize; i++)
            {
                for (int j = 0; j < _swarmSize; j++)
                {
                    _particles[i, j] = new Particle(this);
                }
            }
        }

        /// <summary>
        /// Следующая итерация в поисках лучшего решения
        /// </summary>
        public void NextIteration()
        {
            foreach (var particle in _particles)
            {
                var updatedPosition = particle.Correction();
                var solutionFunc = GetFunc(updatedPosition);
                
                // Если нашли решение лучше
                if (GlobalBestSolutionPosition == FloatArrayExtensions.Zero(Dimension) || solutionFunc < GlobalBestSolutionFunc)
                {
                    GlobalBestSolutionFunc = solutionFunc;
                    GlobalBestSolutionPosition = updatedPosition;
                }
            }
        }
        
        public float GetFunc(float[] position)
        {
            var penalty = GetPenalty(position, 10000.0f);
            var func = position.MultiplicationOfElements(position).SumOfElements();

            return func + penalty;
        }

        private float GetPenalty(float[] position, float ratio)
        {
            var penalty1 = .0f;
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] < MinValues[i])
                {
                    penalty1 += Math.Abs(position[i] - MinValues[i]) * ratio;
                }
            }

            var penalty2 = .0f;
            for (int j = 0; j < position.Length; j++)
            {
                if (position[j] > MaxValues[j])
                {
                    penalty2 += Math.Abs(position[j] - MaxValues[j]) * ratio;
                }
            }

            return penalty1 + penalty2;
        }
    }
}