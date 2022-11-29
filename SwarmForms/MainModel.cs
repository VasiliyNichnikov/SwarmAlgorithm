using System.Collections.Generic;
using System.Collections.ObjectModel;
using SwarmAlgorithm;

namespace SwarmForms
{
    public class MainModel
    {
        public ReadOnlyCollection<float> BestSolutions => _bestSolutions.AsReadOnly();

        private readonly List<float> _bestSolutions = new List<float>();

        public MainModel()
        {
            const int iterations = 100;
            
            var swarm = new Swarm(swarmSize: 10,
                dimension: 1,
                new float[] { -100 },
                new float[] { 100 },
                1f, 5f);
            
            for (int i = 0; i < iterations; i++)
            {
                swarm.NextIteration(ref _bestSolutions);
            }
        }
    }
}