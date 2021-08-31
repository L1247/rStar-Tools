using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
        [ValueDropdown("@ActorDataOverview.GetActorNames()")]
        [InlineButton("ShowName")]
        [SerializeField]
        [LabelWidth(80)]
        [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
                                             ContinuousValidationCheck = true)]
        private string Name;


        [ValueDropdown("@ActorDataOverview.GetActorNames()")]
        [SerializeField]
        [Sirenix.OdinInspector.ValidateInput("@ActorDataOverview.IsStringContains(Name)" ,
                                             ContinuousValidationCheck = true)]
        private List<string> Names;



        private void ShowName()
        {
            Debug.Log($"Name: {Name}");
        }
    }
}