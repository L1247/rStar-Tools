using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class Actor : MonoBehaviour
    {
        [FormerlySerializedAs("name")]
        [SerializeField]
        private ActorName actorName;
    }
}