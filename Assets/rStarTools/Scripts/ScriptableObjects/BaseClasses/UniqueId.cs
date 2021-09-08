#region

using System;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class UniqueId<DO> where DO : ScriptableObject , IDataOverview
    {
    #region Public Variables

        [HideInInspector]
        public string DataId;

        [LabelWidth(90)]
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
            var dataOverview = Utility.GetDataOverview<DO>();
            var validateAll  = dataOverview.ValidateAll(DataId);
            return validateAll;
        }

    #endregion
    }
}