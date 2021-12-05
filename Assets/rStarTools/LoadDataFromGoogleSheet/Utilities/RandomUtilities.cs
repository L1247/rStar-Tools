#region

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

#endregion

namespace AutoBot.Utilities
{
    public static class RandomUtilities
    {
    #region Public Variables

        public const int DefaultValue = -999;

        public static bool Log;
        public static bool UseFake;
        public static int  NextRandomIndex;

        /// <summary>
        ///     Return a random integer number between min [inclusive] and max [inclusive] (Read Only)
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool GetRandomResult(int rate , int max)
        {
            var randomValue = GetRandomValue(max);
            return GetRPNGResult(randomValue , rate);
        }

        public static bool GetRPNGResult(int randomValue , int rate)
        {
            return randomValue <= rate;
        }

        /// <summary>
        ///     start from 1 to max (include)
        /// </summary>
        /// <param name="max">include</param>
        /// <returns></returns>
        public static int GetRandomValue(int max)
        {
            return GetRandomValue(1 , max);
        }

        /// <summary>
        ///     return min to max
        /// </summary>
        /// <param name="min">include</param>
        /// <param name="max">include</param>
        public static int GetRandomValue(int min , int max)
        {
            if (UseFake) return NextRandomIndex;
            var minValue    = min >= max ? max : min;
            var maxValue    = max + 1;
            var randomValue = Random.Range(minValue , maxValue);
            return randomValue;
        }

        public static T GetRandomData<T>(List<T> datas)
        {
            var datasCount = datas.Count;
            Assert.AreNotEqual(0 , datasCount , "count can not be zero");
            if (datasCount == 0) return default;

            var randomIndex = UseFake ? NextRandomIndex : Random.Range(0 , datasCount);
            return datas[randomIndex];
        }

        /// <summary>
        ///     計算圓桌數值
        /// </summary>
        /// <param name="roundTables"></param>
        /// <param name="weightValue">Weight不可為0，不可大於TotalWeight</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception">輸入值違反時會丟Exception</exception>
        public static T GetRoundTableValue<T>(List<RoundTable<T>> roundTables , int weightValue = DefaultValue)
        {
            var totalWeight = roundTables.Sum(table => table.Weight);
            if (roundTables == null)
                throw new Exception("roundTables count is null");
            if (roundTables.Count == 0)
                throw new Exception("roundTables count is 0");
            if (weightValue <= 0 && weightValue != DefaultValue)
                throw new Exception($"Wrong weight value small than min value, {weightValue}");
            if (weightValue > totalWeight)
                throw new Exception(
                    $"Wrong weight value big than max value, {weightValue} , Total weight is {totalWeight}");
            // Is normal path or unit test path
            var randomWeightValue = weightValue == DefaultValue ? GetRandomValue(totalWeight) : weightValue;
            T   result            = default;
            if (Log) Debug.Log($"[GetRoundTableValue] weightValue : {weightValue}");
            for (var index = 0 ; index < roundTables.Count ; index++)
            {
                var roundTable     = roundTables[index];
                var weight         = roundTable.Weight;
                var subtractResult = randomWeightValue - weight;
                if (Log)
                    Debug.Log($"index: {index} , weight : {weight} , value : {roundTable.Value} " +
                              $"totalWeight : {randomWeightValue} , Subtract result : {subtractResult}");
                randomWeightValue = subtractResult;
                if (randomWeightValue <= 0)
                {
                    result = roundTable.Value;
                    break;
                }
            }

            return result;
        }

    #endregion
    }

    [Serializable]
    public class RoundTable<T>
    {
    #region Public Variables

        public int Weight;
        public T   Value;

    #endregion

    #region Public Methods

        public void AddWeight(int weight)
        {
            Weight += weight;
        }

    #endregion
    }
}