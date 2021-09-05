using System;
using System.Collections;
using rStarTools.Scripts.Main.Custom_Attributes;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;
using CustomEditorUtility = EditorUtilities.CustomEditorUtility;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public abstract class NameBase<DO , D> where DO : DataOverviewBase<DO , D> where D : SODataBase
    {
    #region Public Variables

        public string Id => id;

    #endregion

    #region Protected Variables

        protected virtual float Width => LabelText.Length * 12.5f;

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
        [InlineButton("Ping")]
        [LabelWidthString("@Width")]
        [SerializeField]
        [LabelText("@LabelText")]
        private string id;

    #endregion

    #region Protected Methods

        protected abstract DO GetDataOverview();

        protected virtual IEnumerable GetNames()               => GetDataOverview().GetNames();
        protected virtual bool        ValidateId(string value) => GetDataOverview().IsStringContains(value);

    #endregion

    #region Private Methods

        private void ShowId()
        {
            Debug.Log($"<b><color=#ff7c60>[Id]</color></b> <color=#8BFF60>{Id}</color>");
        }

        private void Ping()
        {
            var soDataBase = GetDataOverview().FindData<SODataBase>(Id);
            CustomEditorUtility.PingObject(soDataBase);
            CustomEditorUtility.SelectObject(soDataBase);
        }

    #endregion
    }
}