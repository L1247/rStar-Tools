#region

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

#endregion

namespace rStarTools.MethodInvoker
{
    public class MethodContainerDrawer : OdinValueDrawer<MethodContainer>
    {
    #region Private Variables

        private float      windowWidth;
        private GameObject tmpTarget;
        private GUIStyle   boxStyle;

    #endregion

    #region Protected Methods

        protected override void DrawPropertyLayout(GUIContent label)
        {
            SirenixEditorGUI.BeginToolbarBoxHeader();
            {
                EditorGUI.BeginChangeCheck();
                var targetGameObject = ValueEntry.SmartValue.targetGameObject;
                GUILayout.BeginVertical();
                {
                    Object newTarget = null;
                    GUIHelper.PushColor(Color.cyan);
                    SirenixEditorGUI.BeginBox("Target GameObject");
                    {
                        SirenixEditorGUI.BeginBoxHeader();
                        GUIHelper.PopColor();
                        newTarget = SirenixEditorFields.UnityObjectField(targetGameObject , typeof(GameObject) , true);
                        var width                   = GUILayoutUtility.GetLastRect().width;
                        if (width > 10) windowWidth = width;
                    }
                    SirenixEditorGUI.EndBoxHeader();
                    SirenixEditorGUI.EndBox();

                    GUILayout.Space(10);
                    InsertDivider(Color.green);
                    GUILayout.Space(10);
                    if (EditorGUI.EndChangeCheck())
                    {
                        tmpTarget = (GameObject)newTarget;

                        Property.Tree.DelayActionUntilRepaint(() =>
                        {
                            ValueEntry.WeakSmartValue = new MethodContainer(tmpTarget);
                            GUI.changed               = true;
                            Property.RefreshSetup();
                        });
                    }

                    if (newTarget != null)
                    {
                        var lastInstanceId = -9999;
                        // Draws the rest of the ICustomEvent, and since we've drawn the label, we simply pass along null.
                        for (var i = 0 ; i < Property.Children.Count ; i++)
                        {
                            var child = Property.Children[i];
                            if (child.Name == "Result") continue;
                            var childrens = child.Children;
                            for (var j = 0 ; j < childrens.Count ; j++)
                            {
                                var children = childrens.Get(j);
                                if (children == null) continue;
                                var invokeMethodEntry = children.ValueEntry.WeakSmartValue as MethodEntry;
                                var delegateTarget    = invokeMethodEntry.Delegate.Target as MonoBehaviour;
                                var instanceID        = delegateTarget.GetInstanceID();
                                if (instanceID != lastInstanceId)
                                {
                                    if (lastInstanceId != -9999) InsertDivider(Color.red);
                                    SirenixEditorFields.UnityObjectField(delegateTarget , delegateTarget.GetType() , true);
                                    lastInstanceId = instanceID;
                                }

                                children.Draw();
                            }
                        }
                    }
                }
                GUILayout.EndVertical();
            }

            SirenixEditorGUI.EndToolbarBoxHeader();
        }

    #endregion

    #region Private Methods

        private void InsertDivider(Color color)
        {
            Color.RGBToHSV(color , out var h , out var s , out var v);
            s = 0.5f;
            var hsvToRGB = Color.HSVToRGB(h , s , v);
            color = hsvToRGB;
            SirenixEditorGUI.DrawSolidRect(windowWidth , 3 , color);
        }

    #endregion
    }
}