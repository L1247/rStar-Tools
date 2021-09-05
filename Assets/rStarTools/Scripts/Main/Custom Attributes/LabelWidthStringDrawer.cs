#region

using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
#endif

#endregion

namespace rStarTools.Scripts.Main.Custom_Attributes
{
#if UNITY_EDITOR
    [DrawerPriority(DrawerPriorityLevel.SuperPriority)]
    public class LabelWidthStringDrawer : OdinAttributeDrawer<LabelWidthStringAttribute>
    {
    #region Private Variables

        private ValueResolver<float> widthResolver;

    #endregion

    #region Protected Methods

        protected override void DrawPropertyLayout(GUIContent label)
        {
            LabelWidthStringAttribute attribute  = this.Attribute;
            var                       labelWidth = widthResolver.GetValue();
            if (labelWidth < 0.0)
                GUIHelper.PushLabelWidth(GUIHelper.BetterLabelWidth + labelWidth);
            else
                GUIHelper.PushLabelWidth(labelWidth);
            this.CallNextDrawer(label);
            GUIHelper.PopLabelWidth();
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.widthResolver = ValueResolver.Get<float>(this.Property , this.Attribute.Width);
        }

    #endregion
    }
#endif
}