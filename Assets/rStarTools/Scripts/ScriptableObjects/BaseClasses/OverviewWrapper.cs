#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class OverviewWrapper
    {
    #region Private Variables

        [ShowInInspector]
        // [BoxGroup("@labelText")]
        [ColoredBoxGroup(                                      "@labelText" , .43f , .96f , .64f , 1f ,
                                            BoldLabel = true , ShowIcon = true)]
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
            var displayName = data.DisplayName;
            labelText = $"Current Select Data - [{index}] {displayName}";
        }

    #endregion
    }
}