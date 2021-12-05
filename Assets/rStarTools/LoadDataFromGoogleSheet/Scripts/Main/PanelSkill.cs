#region

using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace LoadDataFromGoogleSheet
{
    public class PanelSkill : MonoBehaviour
    {
    #region Public Variables

        [Required]
        [SerializeField]
        public Button buttonRandomSKill;

    #endregion

    #region Private Variables

        [Required]
        [SerializeField]
        private TMP_Text textAccuracy;

        [Required]
        [SerializeField]
        private TMP_Text textDescription;

        [Required]
        [SerializeField]
        private TMP_Text textName;

        [Required]
        [SerializeField]
        private TMP_Text textPower;

        [Required]
        [SerializeField]
        private TMP_Text textPP;

        [Required]
        [SerializeField]
        private TMP_Text textType;

        [Required]
        [SerializeField]
        private TMP_Text textUuid;

    #endregion

    #region Public Methods

        [Button]
        public void UpdatePanel(int    uuid , string name , string type , string power , string accuracy , string pp ,
                                string description)
        {
            textUuid.text        = uuid.ToString();
            textName.text        = name;
            textType.text        = type;
            textPower.text       = power;
            textAccuracy.text    = accuracy;
            textPP.text          = pp;
            textDescription.text = description;
        }

    #endregion
    }
}