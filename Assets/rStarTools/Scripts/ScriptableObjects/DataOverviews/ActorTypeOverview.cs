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
    public class ActorTypeOverview : SingletonScriptableObject<ActorTypeOverview>
    {
    #region Private Variables

        [SerializeField]
        private List<ActorTypeUniqueId> typeNames = new List<ActorTypeUniqueId>();

    #endregion

    #region Public Methods

        public ActorTypeUniqueId FindUniqueId(string id)
        {
            return typeNames.Find(uniqueId => uniqueId.DataId == id);
        }

        public static IEnumerable GetNames()
        {
            var valueDropdownItems = Instance.typeNames
                                             .Select(element => new ValueDropdownItem
                                             {
                                                 Text  = element.DisplayName ,
                                                 Value = element.DataId
                                             });
            return valueDropdownItems;
        }

        public static bool Validate(string id)
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
                uniqueId.ValidateErrorMessage = "DisplayName is empty.";
                return false;
            }

            var isDisplayNameSame = Instance.typeNames.FindAll(_ => _.DisplayName == displayName).Count < 2;
            if (isDisplayNameSame == false) uniqueId.ValidateErrorMessage = $"Has same DisplayName: {displayName}";
            return isDisplayNameSame;
        }

    #endregion
    }
}