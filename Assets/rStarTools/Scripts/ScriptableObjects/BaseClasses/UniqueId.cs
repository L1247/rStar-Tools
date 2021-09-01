using System;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class UniqueId
    {
        [HideInInspector]
        public string DataId;
        public string DisplayName;

        public UniqueId()
        {
            DataId = Guid.NewGuid().ToString();
        }
    }
}