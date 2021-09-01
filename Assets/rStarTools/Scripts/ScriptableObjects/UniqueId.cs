using System;
using UnityEngine;

namespace ScriptableObjects
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