using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
        // [InlineButton("ShowName")]
        // [InlineButton("ShowHp")]
        // [SerializeField]
        // [LabelWidth(80)]
        // [ValueDropdown("@ActorDataOverview.GetActorNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        // [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
        //                                      ContinuousValidationCheck = true)]
        // private string Name;

        [FormerlySerializedAs("name")]
        [SerializeField]
        private ActorName actorName;

        // [ValueDropdown("@ActorDataOverview.GetActorNames()" , IsUniqueList = false , NumberOfItemsBeforeEnablingSearch =2)]
        // [SerializeField]
        // [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
        //                                      ContinuousValidationCheck = true)]
        // private List<string> Names;

        [SerializeField]
        private List<ActorName> actorNames;

        [SerializeField]
        private ActorDataOverview actorDataOverview;


        private void ShowHp()
        {
            var actorData = actorDataOverview.FindActorData(actorName.Id);
            Debug.Log($"Hp: {actorData.HP}");
        }
    }
}