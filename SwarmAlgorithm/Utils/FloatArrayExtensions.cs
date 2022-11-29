using System;
using System.Linq;

namespace SwarmAlgorithm.Utils
{
    public static class FloatArrayExtensions
    {
        /// <summary>
        /// Сложение элементов массива
        /// Примечание: длина массива должна быть равна
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static float[] AdditionalOfElements(this float[] array1, float[] array2)
        {
            CheckLengthOfArray(array1, array2);

            return array1.Select((a, i) => a + array2[i]).ToArray();
        }

        /// <summary>
        /// Разница элементов массива
        /// Примечание: длина массива должна быть равна
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static float[] DifferenceOfElements(this float[] array1, float[] array2)
        {
            CheckLengthOfArray(array1, array2);
            
            return array1.Select((a, i) => a - array2[i]).ToArray();
        }

        /// <summary>
        /// Умножение элементов массива
        /// Примечание: длина массива должна быть равна
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static float[] MultiplicationOfElements(this float[] array1, float[] array2)
        {
            CheckLengthOfArray(array1, array2);
            
            return array1.Select((a, i) => a * array2[i]).ToArray();
        }

        /// <summary>
        /// Инвертирует значение массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static float[] InvertElements(this float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -array[i];
            }

            return array;
        }

        /// <summary>
        /// Перемножает все элементы массива на число
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float[] MultiplicationByValue(this float[] array, float value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= value;
            }

            return array;
        }

        public static float[] RandomFromZeroToOne(int countElements)
        {
            var result = new float[countElements];
            for (int i = 0; i < countElements; i++)
            {
                result[i] = RandomWrap.NextFloat();
            }

            return result;
        }

        public static float[] Zero(int countElements)
        {
            var result = new float[countElements];
            for (int i = 0; i < countElements; i++)
            {
                result[i] = 0.0f;
            }

            return result;
        }

        public static float SumOfElements(this float[] array)
        {
            var result = 0.0f;
            foreach (var value in array)
            {
                result += value;
            }

            return result;
        }

        private static void CheckLengthOfArray(float[] array1, float[] array2)
        {
            if (array1.Length != array2.Length)
            {
                throw new Exception($"The Length Of Arrays Is Not Equal To. Array1: {array1.Length}. Array2: {array2.Length}");
            }
        }
    }
}