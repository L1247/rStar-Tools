#region

using System.Collections.Generic;
using Main.GameDataStructure;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;
using rStarTools.Scripts.ScriptableObjects.Names;
using ScriptableObjects.Names;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

#endregion

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private ActorDataOverview actorDataOverview;

        [SerializeField]
        private ActorName actorName;

        [SerializeField]
        private List<ActorName> actorNames;

        [FormerlySerializedAs("actorTypeNames")]
        [SerializeField]
        private ActorTypeName actorTypeName;

        [SerializeField]
        private ItemName itemName;

    #endregion

    #region Private Methods

        [Button]
        private void ShowHp()
        {
            var actorData = actorDataOverview.FindData<ActorData>(actorName.Id);
            Debug.Log($"Hp: {actorData.HP}");
        }

    #endregion
    }
}