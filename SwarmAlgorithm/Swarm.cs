using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public class Swarm : ISwarm
    {
        public Vector2 MinValues { get; }
        public Vector2 MaxValues { get; }
        public Vector2 GlobalBestSolutionPosition { get; private set; }
        public float GlobalBestSolutionFunc { get; private set; }

        public float WeightRatioP { get; }
        public float WeightRatioG { get; }

        private readonly int _swarmSize;
        private Particle[,] _particles;

        public Swarm(int swarmSize,
            Vector2 minValues,
            Vector2 maxValues,
            float weightRatioP,
            float weightRatioG)
        {
            _swarmSize = swarmSize;
            MinValues = minValues;
            MaxValues = maxValues;
            
            WeightRatioP = weightRatioP;
            WeightRatioG = weightRatioG;
            
            GlobalBestSolutionFunc = 0.0f;
            GlobalBestSolutionPosition = Vector2.Zero;

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
                if (solutionFunc < GlobalBestSolutionFunc)
                {
                    GlobalBestSolutionFunc = solutionFunc;
                    GlobalBestSolutionPosition = updatedPosition;
                }
            }
        }
        
        public float GetFunc(Vector2 position)
        {
            return (position * position).SumOfElements();
        }
    }
}