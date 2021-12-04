#region

using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

#endregion

namespace LoadDataFromGoogleSheet
{
    public class SkillSceneReference : MonoBehaviour
    {
    #region Public Variables

        [Required]
        public TMP_Text textAccuracy;

        [Required]
        public TMP_Text textDescription;

        [Required]
        public TMP_Text textName;

        [Required]
        public TMP_Text textPower;

        [Required]
        public TMP_Text textPP;

        [Required]
        public TMP_Text textType;

        [Required]
        public TMP_Text textUuid;

    #endregion
    }
}