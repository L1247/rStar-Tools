using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class SODataBase : ScriptableObject
    {
        [SerializeField]
        [HideLabel]
        private UniqueId uniqueId;

        public string DataId      => uniqueId.DataId;
        public string DisplayName => uniqueId.DisplayName;
    }
}