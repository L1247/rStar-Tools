#region

using System;
using System.Reflection;
using Main.GameDataStructure;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class UniqueId
    {
    #region Public Variables

        [ReadOnly]
        public string DataId;

        public string DisplayName;

    #endregion

    #region Constructor

        public UniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }

    #endregion
    }

    [Serializable]
    public class UniqueId<D> where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        [HideInInspector]
        public string DataId;

        [LabelWidth(140)]
        [ValidateInput("@ValidateAll()" , DefaultMessage = "@validateErrorMessage" , ContinuousValidationCheck = true)]
        public string DisplayName;

        [HideInInspector]
        public string validateErrorMessage;

    #endregion

    #region Constructor

        public UniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }

    #endregion

    #region Protected Methods

        protected virtual bool ValidateAll()
        {
            var type         = typeof(SingletonScriptableObject<D>);
            var instance     = type.GetProperty("Instance" , BindingFlags.Public | BindingFlags.Static);
            var singleton    = instance.GetValue(null , null);
            var dataOverview = singleton as IDataOverview;
            var validateAll  = dataOverview.ValidateAll(DataId);
            return validateAll;
        }

    #endregion
    }
}