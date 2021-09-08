#region

using System;
using System.Collections;
using JetBrains.Annotations;
using rStarTools.Scripts.Main.Custom_Attributes;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;
using CustomEditorUtility = EditorUtilities.CustomEditorUtility;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class NameBase2<D> where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string Id => id;

    #endregion

    #region Protected Variables

        [UsedImplicitly]
        protected virtual float LabelWidth => LabelText.Length * 12.5f;

        protected virtual string LabelText => "Name";

    #endregion

    #region Private Variables

    #if UNITY_EDITOR
        [UsedImplicitly]
        internal class NameBase2ValueDrawer<N> : OdinValueDrawer<N> where N : NameBase2<D>
        {
        #region Protected Methods

            protected override void DrawPropertyLayout(GUIContent label)
            {
                Property.Children[0].Draw();
            }

        #endregion
        }
    #endif

        private OdinEditorWindow window;


        [SerializeField]
        [LabelWidthString("@LabelWidth")]
        [LabelText("@LabelText")]
        [ValueDropdown("@GetNames()")]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true)]
        [OnInspectorGUI("IdGUIBefore" , "IdGUIAfter")]
        private string id;

    #endregion

    #region Protected Methods

        protected virtual D GetDataOverview()
        {
            return Utility.GetDataOverview<D>() as D;
        }

        protected virtual IEnumerable GetNames()
        {
            return GetDataOverview().GetNames();
        }

        protected virtual void NameButton()
        {
            var windowExist = window != null;
            var icon        = windowExist ? EditorIcons.Stop : EditorIcons.Stretch;
            if (SirenixEditorGUI.ToolbarButton(icon , windowExist))
            {
                if (windowExist)
                {
                    window.Close();
                    window = null;
                    return;
                }

                var width        = 400;
                var height       = 600;
                var dataOverview = GetDataOverview();
                var btnRect      = GUIHelper.GetCurrentLayoutRect();
                window = OdinEditorWindow.InspectObject(dataOverview);
                var btnRectPosition = GUIUtility.GUIToScreenPoint(btnRect.position);
                btnRectPosition.x   -= width + 30;
                btnRect.position    =  btnRectPosition;
                btnRect.width       =  width;
                btnRect.height      =  height;
                window.position     =  btnRect;
                window.titleContent =  new GUIContent($"{dataOverview.name}" , EditorIcons.StarPointer.Active);
                // window.OnClose      += () => Debug.Log("Window Closed");
                // window.OnBeginGUI   += () => GUILayout.Label("-----------");
                window.OnEndGUI += () =>
                {
                    if (GUILayout.Button("Ping And Select"))
                    {
                        CustomEditorUtility.PingObject(dataOverview);
                        CustomEditorUtility.SelectObject(dataOverview);
                    }

                    if (GUILayout.Button("Close")) window.Close();
                    var e = Event.current;
                    switch (e.type)
                    {
                        case EventType.KeyDown :
                        {
                            if (Event.current.keyCode == KeyCode.Escape)
                                window.Close();
                            break;
                        }
                    }
                };
            }
        }

        protected virtual bool ValidateId(string value)
        {
            return GetDataOverview().Validate(value);
        }

    #endregion

    #region Private Methods

        private void IdGUIAfter()
        {
            NameButton();
            GUILayout.EndHorizontal();
        }

        private void IdGUIBefore()
        {
            GUILayout.BeginHorizontal();
        }

    #endregion
    }
}