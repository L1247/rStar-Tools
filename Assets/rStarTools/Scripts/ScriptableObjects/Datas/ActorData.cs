using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "rStar/ActorData" , order = 0)]
    public class ActorData : SODataBase
    {
        public int HP;
    }
}