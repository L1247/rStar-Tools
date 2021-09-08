#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Main.GameDataStructure
{
    public class ActorTypeOverview : SingletonScriptableObject<ActorTypeOverview> , IDataOverview
    {
    #region Private Variables

        [SerializeField]
        [LabelText("Names")]
        private List<UniqueId<ActorTypeOverview>> ids = new List<UniqueId<ActorTypeOverview>>();

    #endregion

    #region Public Methods

        public UniqueId<ActorTypeOverview> FindUniqueId(string id)
        {
            return ids.Find(uniqueId => uniqueId.DataId == id);
        }

        public IEnumerable GetNames()
        {
            var valueDropdownItems = ids
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
                uniqueId.validateErrorMessage = "DisplayName is empty.";
                return false;
            }

            var isDisplayNameSame = ids.FindAll(_ => _.DisplayName == displayName).Count < 2;
            if (isDisplayNameSame == false) uniqueId.validateErrorMessage = $"Has same DisplayName: {displayName}";
            return isDisplayNameSame;
        }

    #endregion
    }
}