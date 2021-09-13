#region

using EditorUtilities;
using rStarTools.Scripts.ScriptableObjects.Datas;
using rStarTools.Scripts.StringList;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    public class SkillDataOverview : DataOverviewBase<SkillDataOverview , SkillData>
    {
    #region Private Methods

        [Button]
        [GUIColor(1f , 1f , 0f)]
        [PropertyOrder(-1)]
        private void UpdateData()
        {
            ids = CustomEditorUtility.GetScriptableObjects<SkillData>();
        }

    #endregion
    }
}