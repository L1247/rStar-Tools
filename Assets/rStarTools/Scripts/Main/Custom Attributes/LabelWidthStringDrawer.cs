using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace rStarTools.Scripts.Main.Custom_Attributes
{
    [DrawerPriority(DrawerPriorityLevel.SuperPriority)]
    public class LabelWidthStringDrawer : OdinAttributeDrawer<LabelWidthStringAttribute>
    {
    #region Overrides of OdinAttributeDrawer<LabelWidthStringAttribute>

        private ValueResolver<float> widthResolver;

    #region Overrides of OdinDrawer

        protected override void Initialize()
        {
            base.Initialize();
            this.widthResolver = ValueResolver.Get<float>(this.Property , this.Attribute.Width);
        }

    #endregion

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

    #endregion
    }
}