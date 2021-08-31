using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    public class ActorDataBase : ScriptableObject
    {
        [SerializeField]
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
    public struct UniqueId
    {
        public string DataId;
        public string DisplayName;
    }
}