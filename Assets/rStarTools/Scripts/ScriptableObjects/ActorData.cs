using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "rStar/ActorData" , order = 0)]
    public class ActorData: ScriptableObject
    {
        public string Name;
        public string DisplayName;
        public int    HP;
    }
}