using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using EditorUtilities;
using NaughtyAttributes;
using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        // [ValueDropdown("@NameListSo.SkillNames")]
        // [ValueDropdown("@NameListSo.SkillNameArray")]
        [ValueDropdown("SkillNames")]
        [InlineButton("ShowSkillName")]
        [LabelWidth(80)]
        [Sirenix.OdinInspector.ValidateInput("ValueValidation" , ContinuousValidationCheck = true)]
        private string skillName;

        [Dropdown("SkillNames")]
        [InlineButton("ShowStringValue")]
        [Sirenix.OdinInspector.ValidateInput("ValueValidation" , ContinuousValidationCheck = true)]
        [LabelWidth(80)]
        public string stringValue;

        [SerializeField]
        [InlineButton("ShowEnum")]
        [LabelWidth(80)]
        private CustomName customName;

        [ValueDropdown("@ActorDataOverview.GetActorNames()")]
        [InlineButton("ShowName")]
        [SerializeField]
        [LabelWidth(80)]
        private string Name;

        private static string[] SkillNames = new string[]
        {
            // "sd" ,
            "dnfvn" ,
        };

        private bool ValueValidation(string value)
        {
            var list     = SkillNames.ToList();
            var contains = list.Contains(value);
            // if (contains == false)
            // {
            //     skillName = SkillNames[SkillNames.Length - 1];
            // }

            return contains;
        }

        private void ShowSkillName()
        {
            Debug.Log($"skillName {skillName}");
        }

        private void ShowStringValue()
        {
            Debug.Log($"stringValue: {stringValue}");
        }

        private void ShowEnum()
        {
            Debug.Log($"customName: {customName}");
        }

        private void ShowName()
        {
            Debug.Log($"Name: {Name}");
        }
    }
}