namespace SwarmAlgorithm
{
    public interface ISwarm
    {
        int Dimension { get; } // Измерения
        float WeightRatioP { get; }  // localVelocityRatio 
        float WeightRatioG { get; }  // globalVelocityRatio 
        float[] MaxValues { get; }
        float[] MinValues { get; }
        float[] GlobalBestSolutionPosition { get; }
        /// <summary>
        /// Возвращает значение функции в заданной позции
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        float GetFunc(float[] position);
    }
}