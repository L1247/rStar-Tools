#region

using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.Main
{
    public class SkillScript : MonoBehaviour
    {
    #region Private Variables

        // [Dropdown("SkillNames")]
        // [InlineButton("ShowStringValue")]
        // // [Sirenix.OdinInspector.ValidateInput("ValueValidation" , ContinuousValidationCheck = true)]
        // [LabelWidth(120)]
        // public string NaughtyStringValue;

        private static readonly string[] SkillNames =
        {
            "sd" ,
            "nfvn"
        };

        [SerializeField]
        [ValueDropdown("@NameListSo.SkillNames")]
        // [ValueDropdown("SkillNames")]
        [InlineButton("ShowSkillName")]
        [LabelWidth(120)]
        // [Sirenix.OdinInspector.ValidateInput("ValueValidation" ,"Value No Exists")]
        private string skillName;

    #endregion

    #region Private Methods

        private void ShowSkillName()
        {
            Debug.Log($"skillName {skillName}");
        }

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

    #endregion

        // private void ShowStringValue()
        // {
        //     Debug.Log($"NaughtyStringValue: {NaughtyStringValue}");
        // }
    }
}