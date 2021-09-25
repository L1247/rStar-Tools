#region

using rStarTools.Scripts.StringList.Custom_Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace rStarTools.Scripts.StringList
{
    public class OverviewWrapper
    {
    #region Private Variables

        [ShowInInspector]
        [ColoredBoxGroup(                                    "@labelText" , .43f , .96f , .64f , 1f ,
                                           ShowIcon = true , ColorText = false)]
        [InlineEditor(InlineEditorObjectFieldModes.CompletelyHidden)]
        private IUniqueId currentData;

        [ShowInInspector]
        [PropertySpace(SpaceBefore = 15)]
        [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
        private IDataOverview dataOverview;

        private string labelText;
        private string id;

    #endregion

    #region Constructor

        public OverviewWrapper(ScriptableObject dataOverview)
        {
            this.dataOverview = (IDataOverview)dataOverview;
        }

    #endregion

    #region Unity events

        public void Update()
        {
            if (IsCurrentDataExist() == false) ClearCurrentData();
        }

    #endregion

    #region Public Methods

        public void SetSelect(string id)
        {
            this.id = id;
            if (IsCurrentDataExist())
            {
                var index = dataOverview.FindIndex(id);
                var data  = dataOverview.GetUniqueIdByIndex(index);
                currentData = data;
                var displayName = data.DisplayName;
                labelText = $"Current Select Data - [{index}] {displayName}";
            }
            else
            {
                ClearCurrentData();
            }
        }

    #endregion

    #region Private Methods

        private void ClearCurrentData()
        {
            currentData = null;
            labelText   = string.Empty;
        }

        private bool IsCurrentDataExist()
        {
            return dataOverview.FindIndex(id) >= 0;
        }

    #endregion
    }
}