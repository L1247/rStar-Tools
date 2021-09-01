using System;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace ScriptableObjects
{
    public abstract class NameBase
    {
        [ValueDropdown("@GetNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true)]
        [InlineButton("ShowId")]
        [LabelWidth(40)]
        [SerializeField]
        private string Name;

        public string Id => Name;

        private void ShowId()
        {
            Debug.Log($"Name: {Name}");
        }

        internal class NameBaseValueDrawer<T> : OdinValueDrawer<T> where T : NameBase
        {
            protected override void DrawPropertyLayout(GUIContent label)
            {
                this.Property.Children[0].Draw();
            }
        }

        protected abstract IEnumerable GetNames();
        protected         abstract bool        ValidateId(string value);
    }
}