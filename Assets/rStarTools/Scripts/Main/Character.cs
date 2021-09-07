#region

using System.Collections.Generic;
using Main.GameDataStructure;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;
using ScriptableObjects.Names;
using Sirenix.OdinInspector;
using UnityEngine;

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

        [SerializeField]
        private ActorTypeNames actorTypeNames;

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