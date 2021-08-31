using System.Linq;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class SkillScript : MonoBehaviour
    {
        [SerializeField]
        // [ValueDropdown("@NameListSo.SkillNames")]
        [ValueDropdown("SkillNames")]
        [InlineButton("ShowSkillName")]
        [LabelWidth(120)]
        // [Sirenix.OdinInspector.ValidateInput("ValueValidation" , ContinuousValidationCheck = true)]
        private string skillName;

        [Dropdown("SkillNames")]
        [InlineButton("ShowStringValue")]
        // [Sirenix.OdinInspector.ValidateInput("ValueValidation" , ContinuousValidationCheck = true)]
        [LabelWidth(120)]
        public string NaughtyStringValue;

        private static string[] SkillNames = new string[]
        {
            "sd" ,
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
            Debug.Log($"NaughtyStringValue: {NaughtyStringValue}");
        }
    }
}