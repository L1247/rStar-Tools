#region

using System.Reflection;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
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

    #endregion
    }
}