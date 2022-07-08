#region

using System;
using System.Collections;
using JetBrains.Annotations;
using rStarTools.Scripts.StringList.Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using CustomEditorUtility = EditorUtilities.CustomEditorUtility;
#if UNITY_EDITOR
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
#endif

#endregion

namespace rStarTools.Scripts.StringList
{
    [Serializable]
    public class NameBase<D> where D : ScriptableObject , IDataOverview
    {
    #region Public Variables

        public static GUIStyle ToolbarButton
        {
            get
            {
                if (toolbarButton == null)
                {
                #if UNITY_EDITOR
                    toolbarButton = new GUIStyle(EditorStyles.toolbarButton)
                    {
                        fixedHeight   = 20 ,
                        fixedWidth    = 30 ,
                        alignment     = TextAnchor.MiddleCenter ,
                        stretchHeight = true ,
                        stretchWidth  = false
                    };
                #endif
                }

                return toolbarButton;
            }
        }

        public string Id => id;

    #endregion

    #region Protected Variables

        [UsedImplicitly]
        protected virtual float LabelWidth => /*Utility.GetFlexibleWidth(LabelText)*/0;

        protected virtual int overviewHeight => 400;

        protected virtual int overviewWidth => 400;

        protected virtual string LabelText => "Name";

    #endregion

    #region Private Variables

    #if UNITY_EDITOR
        [UsedImplicitly]
        internal class NameBaseValueDrawer<N> : OdinValueDrawer<N> where N : NameBase<D>
        {
        #region Protected Methods

            protected override void DrawPropertyLayout(GUIContent label)
            {
                var parentTextAttribute = Property.GetAttribute<LabelTextAttribute>();
                var parentHasLabelText  = parentTextAttribute != null;
                if (Property.Children.Count == 0) return;
                var idField            = Property.Children[0];
                var labelTextAttribute = idField.GetAttribute<LabelTextAttribute>();
                var hasLabelText       = labelTextAttribute != null;
                if (hasLabelText)
                {
                    if (parentHasLabelText) labelTextAttribute.Text = parentTextAttribute.Text;
                    else labelTextAttribute.Text                    = "@LabelText";
                }

                idField.Draw();
            }

        #endregion
        }
    #endif

        private static GUIStyle toolbarButton;

        private OverviewWrapper overviewWrapper;

    #if UNITY_EDITOR
        private OdinEditorWindow window;
    #endif

        private Rect lastRect;

        [SerializeField]
        [LabelWidthString("@LabelWidth")]
        [LabelText("@LabelText")]
        [ValueDropdown("@GetNames()")]
        [ValidateInput("@ValidateId(Id)" , ContinuousValidationCheck = true ,
                       DefaultMessage = "@StringListDescription.DoesNotContainInDataList")]
        [OnInspectorGUI("IdGUIBefore" , "IdGUIAfter")]
        [OnValueChanged("OnIdChanged")]
        private string id;

    #endregion

    #region Public Methods

        public override bool Equals(object obj)
        {
            var nameBase = obj as NameBase<D>;
            if (nameBase == null) return base.Equals(obj);
            return Id.Equals(nameBase.Id);
        }

        public void SetId(string id)
        {
            this.id = id;
        }

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
            if (windowExist)
            {
                var overviewWrapperExist = overviewWrapper == null;
                if (overviewWrapperExist)
                {
                    OnWindowClose();
                    CloseWindow();
                    OpenNewWindow();
                }
            }

            var icon = windowExist ? EditorIcons.Stop : EditorIcons.Stretch;

            if (GUILayout.Button(icon.Raw , ToolbarButton))
            {
                if (windowExist) CloseWindow();
                else OpenNewWindow();
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
            window = null;
        #endif
        }

        private bool IsWindowExist()
        {
            var windowExist = false;
        #if UNITY_EDITOR
            windowExist = window != null;
        #endif
            return windowExist;
        }

        private void OnEndGUI(D dataOverview)
        {
            overviewWrapper.Update();
            if (GUILayout.Button("Ping And Select DataOverview"))
            {
                CustomEditorUtility.PingObject(dataOverview);
                CustomEditorUtility.SelectObject(dataOverview);
            }

            if (GUILayout.Button("Close Window (Esc)")) CloseWindow();
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
        }

        private void OnIdChanged()
        {
        #if UNITY_EDITOR
            if (IsWindowExist()) overviewWrapper.SetSelect(Id);
        #endif
        }

        private void OnWindowClose()
        {
        #if UNITY_EDITOR
            lastRect = window.position;
        #endif
        }

        private void OpenNewWindow()
        {
        #if UNITY_EDITOR
            var dataOverview  = GetDataOverview();
            var lastRectExist = lastRect != default;
            var rect          = lastRectExist ? lastRect : GUIHelper.GetCurrentLayoutRect();
            overviewWrapper = new OverviewWrapper(dataOverview);
            window          = OdinEditorWindow.InspectObject(overviewWrapper);
            overviewWrapper.SetSelect(id);

            if (lastRectExist == false)
            {
                var btnRectPosition = GUIUtility.GUIToScreenPoint(rect.position);
                btnRectPosition.x -= overviewWidth + 30;
                btnRectPosition.y =  Mathf.Min(btnRectPosition.y , 550);
                rect.position     =  btnRectPosition;
                rect.width        =  overviewWidth;
                rect.height       =  overviewHeight;
            }

            window.position     =  rect;
            window.titleContent =  new GUIContent($"{dataOverview.name}" , EditorIcons.StarPointer.Active);
            window.OnClose      += OnWindowClose;
            // window.OnBeginGUI   += () => GUILayout.Label("-----------");
            window.OnEndGUI += () => OnEndGUI(dataOverview);
        #endif
        }

    #endregion
    }
}