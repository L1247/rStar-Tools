#region

using System;
using JetBrains.Annotations;
using rStarTools.Scripts.Main.Custom_Attributes;
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

        [LabelWidthString("@LabelWidth")]
        [LabelText("顯示名稱:")]
        [ValidateInput("@ValidateAll()" , DefaultMessage = "@validateErrorMessage" , ContinuousValidationCheck = true)]
        public string DisplayName;

    #endregion

    #region Protected Variables

        [UsedImplicitly]
        protected virtual float LabelWidth => Utility.GetFlexibleWidth(DisplayName);

    #endregion

    #region Private Variables

        [UsedImplicitly]
        private string validateErrorMessage;

    #endregion

    #region Constructor

        public UniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }

    #endregion

    #region Public Methods

        public void SetErrorMessage(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                errorMessage = "Something going wrong";

            validateErrorMessage = errorMessage;
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