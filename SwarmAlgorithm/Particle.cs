using System;
using SwarmAlgorithm.Utils;

namespace SwarmAlgorithm
{
    // todo 1) Значения скоростей выходят за края (Нужно ограничить от 0 до 1)
    // todo 2) Значение позиций выходят за края карты, нужно ограничить от minValues до maxValues
    public class Particle
    {
        private Vector2 _localBestSolutionPosition;
        private float _localBestSolutionFunc;
        
        private Vector2 _position;
        private Vector2 _velocity;
        private readonly ISwarm _swarm;

        public Particle(ISwarm swarm)
        {
            _swarm = swarm;
            _position = InitStartPosition(swarm);
            _velocity = InitStartVelocity(swarm);

            Console.WriteLine($"Start position: {_position}");
            Console.WriteLine($"Start velocity: {_velocity}");
            
            _localBestSolutionPosition = Vector2.Zero;
            _localBestSolutionFunc = _swarm.GetFunc(_position);
        }

        private Vector2 InitStartPosition(ISwarm swarm)
        {
            var different = swarm.MaxValues - swarm.MinValues;
            var added = different + swarm.MinValues;
            return Vector2.RandomFromZeroToOne * added; 
        }

        private Vector2 InitStartVelocity(ISwarm swarm)
        {
            var minValues = swarm.MaxValues - swarm.MinValues;
            var maxValues = minValues;

            minValues = -minValues;
            
            var different = maxValues - minValues;
            var added = different + minValues;
            
            return Vector2.RandomFromZeroToOne * added;
        }

        /// <summary>
        /// Корректируется на основе обновленного лучшего решения
        /// </summary>
        /// <returns></returns>
        public Vector2 Correction()
        {
            // Случайный вектор для коррекции скорости с учетом лучшей позиции данной частицы
            var r1 = Vector2.RandomFromZeroToOne;
            // Случайный вектор для коррекции скорости с учетом лучшей глобальной позиции всех частиц
            var r2 = Vector2.RandomFromZeroToOne;
            
            var newVelocity = _velocity + _swarm.WeightRatioP * r1 * (_localBestSolutionPosition - _position) + 
                              _swarm.WeightRatioG * r2 * (_swarm.GlobalBestSolutionPosition - _position);
            var newPosition = _position + newVelocity;

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