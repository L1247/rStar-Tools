#region

using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

#endregion

namespace Main.GameDataStructure
{
    [Serializable]
    public class ActorTypeNames
    {
    #region Public Variables

        public string Id => id;

    #endregion

    #region Private Variables

        [SerializeField]
        [LabelText("角色類型:")]
        [LabelWidth(60)]
        [ValueDropdown("@ActorTypeOverview.GetNames()")]
        [ValidateInput("@ActorTypeOverview.Validate(Id)" , ContinuousValidationCheck = true)]
        private string id;

    #endregion
    }

#if UNITY_EDITOR
    internal class ActorTypeNamesDrawer : OdinValueDrawer<ActorTypeNames>
    {
    #region Protected Methods

        protected override void DrawPropertyLayout(GUIContent label)
        {
            Property.Children[0].Draw();
        }

    #endregion
    }
#endif
}