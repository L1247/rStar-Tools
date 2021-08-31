using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    public class ActorDataBase : ScriptableObject
    {
        [SerializeField]
        [HideLabel]
        private UniqueId uniqueId;

        public string DataId      => uniqueId.DataId;
        public string DisplayName => uniqueId.DisplayName;
    }

    [CreateAssetMenu(fileName = "ActorData" , menuName = "rStar/ActorData" , order = 0)]
    public class ActorData : ActorDataBase
    {
        public int HP;
    }

    [Serializable]
    public struct ActorName
    {
        [ValueDropdown("@ActorDataOverview.GetActorNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        public string Name;
    }

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