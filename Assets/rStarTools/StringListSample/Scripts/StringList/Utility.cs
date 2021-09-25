#region

using System;
using System.Reflection;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    public class Utility
    {
    #region Public Methods

        public static IDataOverview GetDataOverview<D>() where D : ScriptableObject , IDataOverview
        {
            var type         = typeof(SingletonScriptableObject<D>);
            var instance     = type.GetProperty("Instance" , BindingFlags.Public | BindingFlags.Static);
            var singleton    = instance.GetValue(null , null);
            var dataOverview = singleton as D;
            return dataOverview;
        }

        public static float GetFlexibleWidth(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            const int flexibleSpace = 11;
            var       width         = text.Length * flexibleSpace;
            return width;
        }

        public static bool IsSubclassOfRawGeneric(Type generic , Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur) return true;

                toCheck = toCheck.BaseType;
            }

            return false;
        }

    #endregion
    }
}