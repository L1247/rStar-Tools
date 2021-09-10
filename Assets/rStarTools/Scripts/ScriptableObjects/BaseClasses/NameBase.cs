#region

using System;
using System.Collections;
using JetBrains.Annotations;
using rStarTools.Scripts.Main.Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using CustomEditorUtility = EditorUtilities.CustomEditorUtility;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
#endif

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    [Serializable]
    public class NameBase<D> where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public string Id => id;

    #endregion

    #region Protected Variables

        protected virtual bool useOverviewWrapper => true;

        [UsedImplicitly]
        protected virtual float LabelWidth => Utility.GetFlexibleWidth(LabelText);

        protected virtual int overviewHeight => 400;

        protected virtual int overviewWidth => 400;

        protected virtual string LabelText => "Name";

    #endregion

    #region Private Variables

    #if UNITY_EDITOR
        [UsedImplicitly]
        internal class NameBase2ValueDrawer<N> : OdinValueDrawer<N> where N : NameBase<D>
        {
        #region Protected Methods

            protected override void DrawPropertyLayout(GUIContent label)
            {
                Property.Children[0].Draw();
            }

        #endregion
        }
    #endif

        private OverviewWrapper overviewWrapper;

    #if UNITY_EDITOR
        private OdinEditorWindow window;
    #endif

        private readonly string errorMessage = "此筆資料不存在於資料陣列內";

        [SerializeField]
        [LabelWidthString("@LabelWidth")]
        [LabelText("@LabelText")]
        [ValueDropdown("@GetNames()")]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true , DefaultMessage = "@errorMessage")]
        [OnInspectorGUI("IdGUIBefore" , "IdGUIAfter")]
        [OnValueChanged("OnIdChanged")]
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

        protected void IdGUIAfter()
        {
            NameButton();
            GUILayout.EndHorizontal();
        }

        protected void IdGUIBefore()
        {
            GUILayout.BeginHorizontal();
        }

        protected virtual void NameButton()
        {
        #if UNITY_EDITOR
            var windowExist = IsWindowExist();
            // Debug.Log($" {GetType()} , {windowExist}");
            var icon = windowExist ? EditorIcons.Stop : EditorIcons.Stretch;
            if (SirenixEditorGUI.ToolbarButton(icon , windowExist))
            {
                if (windowExist)
                {
                    CloseWindow();
                    return;
                }

                var dataOverview = GetDataOverview();
                var btnRect      = GUIHelper.GetCurrentLayoutRect();
                if (useOverviewWrapper)
                {
                    overviewWrapper = new OverviewWrapper(dataOverview);
                    window          = OdinEditorWindow.InspectObject(overviewWrapper);
                    overviewWrapper.SetSelect(id);
                }
                else
                {
                    window = OdinEditorWindow.InspectObject(dataOverview);
                }

                var btnRectPosition = GUIUtility.GUIToScreenPoint(btnRect.position);
                btnRectPosition.x   -= overviewWidth + 30;
                btnRectPosition.y   =  Mathf.Min(btnRectPosition.y , 550);
                btnRect.position    =  btnRectPosition;
                btnRect.width       =  overviewWidth;
                btnRect.height      =  overviewHeight;
                window.position     =  btnRect;
                window.titleContent =  new GUIContent($"{dataOverview.name}" , EditorIcons.StarPointer.Active);
                window.OnClose      += () => { };
                // window.OnBeginGUI   += () => GUILayout.Label("-----------");
                window.OnEndGUI += () =>
                {
                    if (GUILayout.Button("Ping And Select"))
                    {
                        CustomEditorUtility.PingObject(dataOverview);
                        CustomEditorUtility.SelectObject(dataOverview);
                    }

                    if (GUILayout.Button("Close")) CloseWindow();
                    var e = Event.current;
                    switch (e.type)
                    {
                        case EventType.KeyDown :
                        {
                            if (Event.current.keyCode == KeyCode.Escape)
                                OnCloseKeyDown();
                            break;
                        }
                    }
                };
            }
        #endif
        }

        protected virtual void OnCloseKeyDown()
        {
            CloseWindow();
        }

        protected virtual bool ValidateId(string value)
        {
            return GetDataOverview().Validate(value);
        }

    #endregion

    #region Private Methods

        private void CloseWindow()
        {
        #if UNITY_EDITOR
            window.Close();
        #endif
            window = null;
        }

        private bool IsWindowExist()
        {
            bool windowExist;
        #if UNITY_EDITOR
            windowExist = window != null;
        #endif
            return windowExist;
        }

        private void OnIdChanged()
        {
        #if UNITY_EDITOR
            if (IsWindowExist() && useOverviewWrapper)
                overviewWrapper.SetSelect(Id);
        #endif
        }

    #endregion
    }

    public class OverviewWrapper
    {
    #region Private Variables

        [ShowInInspector]
        // [BoxGroup("@labelText")]
        [ColoredBoxGroup("@labelText" , .43f , .96f , .64f , 1f ,
                         BoldLabel = true)]
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        private object currentData;

        [ShowInInspector]
        [PropertySpace(SpaceBefore = 15)]
        [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        private IDataOverview dataOverview;

        private string labelText;

    #endregion

    #region Constructor

        public OverviewWrapper(ScriptableObject dataOverview)
        {
            this.dataOverview = (IDataOverview)dataOverview;
        }

    #endregion

    #region Public Methods

        public void SetSelect(string id)
        {
            var index = dataOverview.FindIndex(id);
            var data  = dataOverview.GetData(index);
            currentData = data;
            labelText   = $"Current Select Data - [Index {index}]";
        }

    #endregion
    }
}