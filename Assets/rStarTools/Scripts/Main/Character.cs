using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace rStarTools.Scripts.Main
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        [ValueDropdown("SkillNames")]
        [InlineButton("ShowSkillName")]
        [LabelWidth(60)]
        [Sirenix.OdinInspector.ValidateInput("ValueValidation",ContinuousValidationCheck = true)]
        private string skillName;

        [Dropdown("SkillNames")]
        [InlineButton("ShowStringValue")]
        [Sirenix.OdinInspector.ValidateInput("ValueValidation",ContinuousValidationCheck = true)]
        public string stringValue;

        [SerializeField]
        private CustomName customName;

        private static string[] SkillNames = new string[]
        {
            // "sd" ,
            "dnfvn" ,
        };

        private bool ValueValidation(string value)
        {
            var list            = SkillNames.ToList();
            var contains = list.Contains(value);
            if (contains==false)
            {
                skillName = SkillNames[SkillNames.Length - 1];
            }
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
    }

    public enum CustomName
    {
        C , B , A ,
    }
}