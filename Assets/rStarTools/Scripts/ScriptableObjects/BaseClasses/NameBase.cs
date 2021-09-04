using System;
using System.Collections;
using rStarTools.Scripts.Main.Custom_Attributes;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public abstract class NameBase<DO , D> where DO : DataOverviewBase<DO , D> where D : SODataBase
    {
    #region Public Variables

        public string Id => Name;

    #endregion

    #region Protected Variables

        protected virtual string LabelText => "Name";

    #endregion

    #region Private Variables

        internal class NameBaseValueDrawer<N> : OdinValueDrawer<N> where N : NameBase<DO , D>
        {
        #region Protected Methods

            protected override void DrawPropertyLayout(GUIContent label)
            {
                this.Property.Children[0].Draw();
            }

        #endregion
        }

        [ValueDropdown("@GetNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true)]
        [InlineButton("ShowId")]
        [LabelWidthString("@Width")]
        [SerializeField]
        [LabelText("@LabelText")]
        private string Name;

        protected virtual float Width => LabelText.Length * 12.5f;

    #endregion

    #region Protected Methods

        protected abstract DO GetDataOverview();

        protected virtual IEnumerable GetNames()               => GetDataOverview().GetNames();
        protected virtual bool        ValidateId(string value) => GetDataOverview().IsStringContains(value);

    #endregion

    #region Private Methods

        private void ShowId()
        {
            Debug.Log($"Name: {Name}");
        }

    #endregion
    }
}