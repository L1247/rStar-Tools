#region

using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    public class SODataBase<DO> : ScriptableObject , IUniqueId where DO : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string DataId      => uniqueId.DataId;
        public string DisplayName => uniqueId.DisplayName;

    #endregion

    #region Protected Variables

        [UsedImplicitly]
        protected string validateErrorMessage;

    #endregion

    #region Private Variables

        [SerializeField]
        [HideLabel]
        [ValidateInput("@ValidateAll()" , DefaultMessage = "@validateErrorMessage" , ContinuousValidationCheck = true)]
        private UniqueId<DO> uniqueId;

    #endregion

    #region Public Methods

        public void SetDataId(string id)
        {
            uniqueId.SetDataId(id);
        }

        public void SetDisplayName(string newDisplayName)
        {
            uniqueId.SetDisplayName(newDisplayName);
        }

    #endregion

    #region Protected Methods

        protected virtual DO GetDataOverview()
        {
            var dataOverview = Utility.GetDataOverview<DO>();
            return dataOverview as DO;
        }

        protected virtual bool ValidateAll()
        {
            validateErrorMessage = string.Empty;
            var result         = ValidatorDataOverview();
            if (result) result = ValidateDisplayName();
            if (result) result = ValidateSameDisplayName();
            if (result) result = ValidateOthers();
            return result;
        }

        protected virtual bool ValidateDisplayName()
        {
            var displayName              = uniqueId.DisplayName;
            var displayNameIsNullOrEmpty = string.IsNullOrEmpty(displayName);
            if (displayNameIsNullOrEmpty)
                validateErrorMessage = StringListDescription.DisplayNameIsEmpty;
            return displayNameIsNullOrEmpty == false;
        }

        protected virtual bool ValidateOthers()
        {
            return true;
        }

        protected virtual bool ValidateSameDisplayName()
        {
            var displayName = uniqueId.DisplayName;
            var ids         = GetDataOverview().GetAllUniqueId();
            var isDisplayNameSame = ids.FindAll(_ =>
            {
                if (_ == null) return false;
                var sameDisplayName = _.DisplayName == displayName;
                return sameDisplayName;
            }).Count > 1;
            if (isDisplayNameSame)
                validateErrorMessage = $"{StringListDescription.SameDisplayName}: {displayName}";
            return isDisplayNameSame == false;
        }

        protected virtual bool ValidatorDataOverview()
        {
            var dataOverview                         = GetDataOverview();
            var overviewIsNull                       = dataOverview == null;
            if (overviewIsNull) validateErrorMessage = StringListDescription.OverviewIsNull;
            return overviewIsNull == false;
        }

    #endregion
    }
}