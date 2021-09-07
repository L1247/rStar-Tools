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
        private List<UniqueId<ActorTypeOverview>> typeNames = new List<UniqueId<ActorTypeOverview>>();

    #endregion

    #region Public Methods

        public UniqueId<ActorTypeOverview> FindUniqueId(string id)
        {
            return typeNames.Find(uniqueId => uniqueId.DataId == id);
        }

        public IEnumerable GetNames()
        {
            var valueDropdownItems = Instance.typeNames
                                             .Select(element => new ValueDropdownItem
                                             {
                                                 Text  = element.DisplayName ,
                                                 Value = element.DataId
                                             });
            return valueDropdownItems;
        }

        public bool Validate(string id)
        {
            var containsId = Instance.FindUniqueId(id) != null;
            return containsId;
        }

        public bool ValidateAll(string id)
        {
            var uniqueId    = Instance.FindUniqueId(id);
            var displayName = uniqueId.DisplayName;
            if (string.IsNullOrEmpty(displayName))
            {
                uniqueId.validateErrorMessage = "DisplayName is empty.";
                return false;
            }

            var isDisplayNameSame = Instance.typeNames.FindAll(_ => _.DisplayName == displayName).Count < 2;
            if (isDisplayNameSame == false) uniqueId.validateErrorMessage = $"Has same DisplayName: {displayName}";
            return isDisplayNameSame;
        }

    #endregion
    }
}