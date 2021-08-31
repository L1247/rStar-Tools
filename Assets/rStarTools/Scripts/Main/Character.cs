using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
        [InlineButton("ShowName")]
        [InlineButton("ShowHp")]
        [SerializeField]
        [LabelWidth(80)]
        [ValueDropdown("@ActorDataOverview.GetActorNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
                                             ContinuousValidationCheck = true)]
        private string Name;


        [ValueDropdown("@ActorDataOverview.GetActorNames()" , IsUniqueList = false , NumberOfItemsBeforeEnablingSearch =2)]
        [SerializeField]
        [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
                                             ContinuousValidationCheck = true)]
        private List<string> Names;

        [SerializeField]
        private ActorDataOverview actorDataOverview;


        private void ShowName()
        {
            Debug.Log($"Name: {Name}");
        }

        private void ShowHp()
        {
            var actorData = actorDataOverview.FindActorData(Name);
            Debug.Log($"Hp: {actorData.HP}");
        }
    }
}