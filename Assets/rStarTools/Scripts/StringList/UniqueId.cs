#region

using System;
using JetBrains.Annotations;
using rStarTools.Scripts.StringList.Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    [Serializable]
    public class UniqueId<DO> : IUniqueId where DO : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string DataId      => dataId;
        public string DisplayName => displayName;

    #endregion

    #region Protected Variables

        [UsedImplicitly]
        protected virtual float LabelWidth => Utility.GetFlexibleWidth(LabelText);

        protected virtual string LabelText => "顯示名稱:";

    #endregion

    #region Private Variables

        [UsedImplicitly]
        private string validateErrorMessage;

        [HideInInspector]
        [SerializeField]
        private string dataId;

        [LabelWidthString("@LabelWidth")]
        [LabelText("@LabelText")]
        [ValidateInput("@ValidateAll()" , DefaultMessage = "@validateErrorMessage" , ContinuousValidationCheck = true)]
        [HorizontalGroup("UniqueId")]
        [SerializeField]
        [TableColumnWidth(200)]
        private string displayName;

    #endregion

    #region Constructor

        public UniqueId()
        {
            dataId = Guid.NewGuid().ToString();
        }

    #endregion

    #region Public Methods

        public void SetDataId(string id)
        {
            dataId = id;
        }

        public void SetDisplayName(string newDisplayName)
        {
            displayName = newDisplayName;
        }

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
            var dataOverview = GetDataOverview();
            var validateAll  = dataOverview.ValidateAll(dataId);
            return validateAll;
        }

    #endregion

    #region Private Methods

        private IDataOverview GetDataOverview()
        {
            var dataOverview = Utility.GetDataOverview<DO>();
            return dataOverview;
        }

    #endregion
    }
}