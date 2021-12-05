#region

using System;
using UnityEngine;

#endregion

namespace ThirdParty.Utilities
{
    /// <summary>
    ///     https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
    /// </summary>
    public static class JsonHelper
    {
    #region Public Variables

        public static string FixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }

        public static string ToJson<T>(T[] array)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array , bool prettyPrint)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper , prettyPrint);
        }

        public static T[] FromJson<T>(string json , bool needToFix = false)
        {
            if (needToFix) json = FixJson(json);
            var wrapper         = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

    #endregion

    #region Private Variables

        [Serializable]
        private class Wrapper<T>
        {
        #region Public Variables

            public T[] Items;

        #endregion
        }

    #endregion
    }
}