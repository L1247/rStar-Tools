using rStarTools.Scripts.ScriptableObjects.Names;
using ScriptableObjects;
using ScriptableObjects.Names;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class Actor : MonoBehaviour
    {
        [SerializeField]
        private ActorName actorName;
    }
}