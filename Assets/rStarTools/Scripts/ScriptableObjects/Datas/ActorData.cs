#region

using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    public class ActorData : SODataBase<ActorDataOverview>
    {
    #region Public Variables

        [LabelText("資料棄用")]
        public bool Deactivate;

        public int HP;

    #endregion
    }
}