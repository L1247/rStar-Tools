using System;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class ActorName
    {
        [ValueDropdown("@GetNames()" , NumberOfItemsBeforeEnablingSearch = 2)]
        [Sirenix.OdinInspector.ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true)]
        [InlineButton("ShowId")]
        [LabelWidth(40)]
        [SerializeField]
        private string Name;

        public string Id => Name;

        private void ShowId()
        {
            Debug.Log($"Name: {Name}");
        }

        internal class ActorNameValueDrawer : OdinValueDrawer<ActorName>
        {
            protected override void DrawPropertyLayout(GUIContent label)
            {
                this.Property.Children[0].Draw();
            }
        }

        protected IEnumerable GetNames()               => ActorDataOverview.GetActorNames();
        protected bool        ValidateId(string value) => ActorDataOverview.IsStringContains(value);
    }
}