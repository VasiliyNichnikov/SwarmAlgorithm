using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public interface ISwarm
    {
        public float[] MaxValues { get; }
        public float[] MinValues { get; }
        public Vector2 GlobalBestSolution { get; }
    }
}