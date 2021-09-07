#region

using System;
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
    public class ActorTypeUniqueId
    {
    #region Public Variables

        [HideInInspector]
        public string DataId;

        [LabelWidth(140)]
        [ValidateInput("@ValidateAll()" , DefaultMessage = "@ValidateErrorMessage" , ContinuousValidationCheck = true)]
        public string DisplayName;

        [HideInInspector]
        public string ValidateErrorMessage;

    #endregion

    #region Constructor

        public ActorTypeUniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }

    #endregion

    #region Protected Methods

        protected virtual bool ValidateAll()
        {
            return ActorTypeOverview.Instance.ValidateAll(DataId);
        }

    #endregion
    }
}