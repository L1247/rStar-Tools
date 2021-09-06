#region

using System;
using System.Collections;
using rStarTools.Scripts.Main.Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using CustomEditorUtility = EditorUtilities.CustomEditorUtility;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
#endif

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public abstract class NameBase<DO , D> where DO : DataOverviewBase<DO , D> where D : SODataBase
    {
    #region Public Variables

        public string Id => id;

    #endregion

    #region Protected Variables

        protected virtual float LabelWidth => LabelText.Length * 12.5f;

        protected virtual string LabelText => "Name";

    #endregion

    #region Private Variables

    #if UNITY_EDITOR
        internal class NameBaseValueDrawer<N> : OdinValueDrawer<N> where N : NameBase<DO , D>
        {
        #region Protected Methods

            protected override void DrawPropertyLayout(GUIContent label)
            {
                this.Property.Children[0].Draw();
            }

        #endregion
        }
    #endif

        [ValueDropdown("@GetNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true)]
        [InlineButton("ShowId")]
        [InlineButton("Ping")]
        [LabelWidthString("@LabelWidth")]
        [SerializeField]
        [LabelText("@LabelText")]
        private string id;

    #endregion

    #region Protected Methods

        protected abstract DO GetDataOverview();

        protected virtual IEnumerable GetNames()
        {
            return GetDataOverview().GetNames();
        }

        protected virtual bool ValidateId(string value)
        {
            return GetDataOverview().Validate(value);
        }

    #endregion

    #region Private Methods


        private void Ping()
        {
            var soDataBase = GetDataOverview().FindData<SODataBase>(Id);
            CustomEditorUtility.PingObject(soDataBase);
            CustomEditorUtility.SelectObject(soDataBase);
        }

        private void ShowId()
        {
            Debug.Log($"<b><color=#ff7c60>[Id]</color></b> <color=#8BFF60>{Id}</color>");
        }

    #endregion
    }
}