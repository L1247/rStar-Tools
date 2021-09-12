#region

using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using UnityEngine;
#if UNITY_EDITOR
#if ODIN_INSPECTOR_3
using Sirenix.Utilities.Editor;
#endif

#endif

#endregion

#if UNITY_EDITOR
namespace rStarTools.Scripts.StringList.Custom_Attributes
{
    public class ColoredBoxGroupDrawer : OdinGroupDrawer<ColoredBoxGroupAttribute>
    {
    #region Protected Methods

        /// <summary>
        ///     Draw the stuff
        /// </summary>
        /// <param name="label">Label string</param>
        protected override void DrawPropertyLayout(GUIContent label)
        {
            GUILayout.Space(Attribute.MarginTop);

            var headerLabel = Attribute.LabelText;

            if (Attribute.ShowLabel)
            {
            #if ODIN_INSPECTOR_3
                labelGetter.DrawError();
                headerLabel = labelGetter.GetValue();
            #endif

                if (string.IsNullOrEmpty(headerLabel)) headerLabel = "";
            }

            var color = new Color(Attribute.R , Attribute.G , Attribute.B , Attribute.A);
            // GUIHelper.PushColor(color);
            GUI.contentColor    = color;
            GUI.backgroundColor = color;
            SirenixEditorGUI.BeginBox();
            SirenixEditorGUI.BeginBoxHeader();
            {
                // GUIHelper.PopColor();
                if (Attribute.ShowLabel)
                {
                    if (Attribute.ShowIcon)
                        GUILayout.Label(EditorIcons.Tag.Raw , GUILayout.Width(20) , GUILayout.MaxHeight(20));

                    if (Attribute.CenterLabel)
                        SirenixEditorGUI.Title(headerLabel , null , TextAlignment.Center , false , Attribute.BoldLabel);
                    else
                        SirenixEditorGUI.Title(headerLabel , null , TextAlignment.Left , false , Attribute.BoldLabel);
                }
            }
            GUI.contentColor    = Color.white;
            GUI.backgroundColor = Color.white;
            SirenixEditorGUI.EndBoxHeader();

            for (var i = 0 ; i < Property.Children.Count ; i++) Property.Children[i].Draw();

            SirenixEditorGUI.EndBox();

            GUILayout.Space(Attribute.MarginBottom);
        }

    #endregion

    #if ODIN_INSPECTOR_3
        private ValueResolver<string> labelGetter;

        /// <summary>
        ///     initialize values for colors, labels, etc
        /// </summary>
        protected override void Initialize()
        {
            labelGetter = ValueResolver.GetForString(Property , Attribute.LabelText ?? Attribute.GroupName);
        }
    #endif
    }
}
#endif