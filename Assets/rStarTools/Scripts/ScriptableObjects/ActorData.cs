using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "rStar/ActorData" , order = 0)]
    public class ActorData : SODataBase
    {
        public int HP;
    }
}