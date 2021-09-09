#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class DataOverviewBase2<D> : SingletonScriptableObject<D> , IDataOverview
    where D : ScriptableObject , IDataOverview
    {
    #region Protected Variables

        [SerializeField]
        [LabelText("Names")]
        protected List<UniqueId<D>> ids = new List<UniqueId<D>>();

    #endregion

    #region Public Methods

        public UniqueId<D> FindUniqueId(string id)
        {
            return ids.Find(uniqueId => uniqueId.DataId == id);
        }

        public virtual IEnumerable GetNames()
        {
            var valueDropdownItems = ids
                                     .Where(id => string.IsNullOrEmpty(id.DisplayName) == false)
                                     .Select(element => new ValueDropdownItem
                                     {
                                         Text  = element.DisplayName ,
                                         Value = element.DataId
                                     });
            return valueDropdownItems;
        }

        public bool Validate(string id)
        {
            var containsId = FindUniqueId(id) != null;
            return containsId;
        }

        public bool ValidateAll(string id)
        {
            var uniqueId    = FindUniqueId(id);
            var displayName = uniqueId.DisplayName;
            if (string.IsNullOrEmpty(displayName))
            {
                // uniqueId.validateErrorMessage = "DisplayName is empty.";
                uniqueId.validateErrorMessage = "顯示名稱不能為空";
                return false;
            }

            var isDisplayNameSame = ids.FindAll(_ => _.DisplayName == displayName).Count < 2;
            if (isDisplayNameSame == false) uniqueId.validateErrorMessage = $"Has same DisplayName: {displayName}";
            return isDisplayNameSame;
        }

    #endregion
    }
}