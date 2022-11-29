using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    public class Particle
    {
        private float[] _localBestSolutionPosition;
        private float _localBestSolutionFunc;

        private float[] _position;
        private float[] _velocity;
        private readonly ISwarm _swarm;

        public Particle(ISwarm swarm)
        {
            _swarm = swarm;
            _position = InitStartPosition(swarm);
            _velocity = InitStartVelocity(swarm);

            _localBestSolutionPosition = _position;
            _localBestSolutionFunc = _swarm.GetFunc(_position);
        }

        private float[] InitStartPosition(ISwarm swarm)
        {
            var different = swarm.MaxValues.DifferenceOfElements(swarm.MinValues);
            var added = different.AdditionalOfElements(swarm.MinValues);
            return FloatArrayExtensions.RandomFromZeroToOne(_swarm.Dimension).MultiplicationOfElements(added);
        }

        private float[] InitStartVelocity(ISwarm swarm)
        {
            var minValues = swarm.MaxValues.DifferenceOfElements(swarm.MinValues);
            var maxValues = minValues;

            minValues = minValues.InvertElements();

            var different = maxValues.DifferenceOfElements(minValues);
            var added = different.AdditionalOfElements(minValues);

            return FloatArrayExtensions.RandomFromZeroToOne(_swarm.Dimension).MultiplicationOfElements(added);
        }

        /// <summary>
        /// Корректируется на основе обновленного лучшего решения
        /// </summary>
        /// <returns></returns>
        public float[] Correction()
        {
            // Случайный вектор для коррекции скорости с учетом лучшей позиции данной частицы
            var currentBestPosition = FloatArrayExtensions.RandomFromZeroToOne(_swarm.Dimension);
            
            // Случайный вектор для коррекции скорости с учетом лучшей глобальной позиции всех частиц
            var globalBestPosition = FloatArrayExtensions.RandomFromZeroToOne(_swarm.Dimension);

            var newVelocityPart1 = _localBestSolutionPosition.DifferenceOfElements(_position)
                .MultiplicationOfElements(currentBestPosition).MultiplicationByValue(_swarm.WeightRatioP);

            var newVelocityPart2 = _swarm.GlobalBestSolutionPosition.DifferenceOfElements(_position)
                .MultiplicationOfElements(globalBestPosition).MultiplicationByValue(_swarm.WeightRatioG);
            
            var newVelocity = _velocity.AdditionalOfElements(newVelocityPart1).AdditionalOfElements(newVelocityPart2);
            var newPosition = _position.AdditionalOfElements(newVelocity);

            _velocity = newVelocity;
            _position = newPosition;

            var solutionFunc = _swarm.GetFunc(_position);
            if (solutionFunc < _localBestSolutionFunc)
            {
                _localBestSolutionFunc = solutionFunc;
                _localBestSolutionPosition = _position;
            }

            return _position;
        }
    }
}