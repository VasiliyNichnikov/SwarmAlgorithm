using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public interface ISwarm
    {
        float WeightRatioP { get; }  // localVelocityRatio 
        float WeightRatioG { get; }  // globalVelocityRatio 
        Vector2 MaxValues { get; }
        Vector2 MinValues { get; }
        Vector2 GlobalBestSolutionPosition { get; }
        /// <summary>
        /// Возвращает значение функции в заданной позции
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        float GetFunc(Vector2 position);
    }
}