using System;

namespace SwarmAlgorithm
{
    public class Swarm
    {
        private int _swarmSize;
        private int _minValues;
        private int _maxValues;
        private float _currentVelocityPosition;
        private float _localVelocityPosition;
        private float _globalVelocityPosition;
        private Particle[,] _particles;

        public Swarm(int swarmSize, 
            int minValues, 
            int maxValues, 
            float currentVelocityPosition,
            float localVelocityPosition,
            float globalVelocityPosition)
        {
            _swarmSize = swarmSize;
            _minValues = minValues;
            _maxValues = maxValues;
            _currentVelocityPosition = currentVelocityPosition;
            _localVelocityPosition = localVelocityPosition;
            _globalVelocityPosition = globalVelocityPosition;
        }

        private void InitSwarm()
        {
            _particles = new Particle[_swarmSize, _swarmSize];
            for (int i = 0; i < _swarmSize; i++)
            {
                for (int j = 0; j < _swarmSize; j++)
                {
                    // _particles[i, j] = new Particle()
                }
            }
        }
        
    }
}