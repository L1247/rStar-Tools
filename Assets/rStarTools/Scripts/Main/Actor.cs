using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.Main
{
    public class Actor : MonoBehaviour
    {
        [SerializeField]
        [HideLabel]
        private ActorName actorName;
    }
}