#region

using System;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.StringList;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    [Serializable]
    public class ActorData : DataBase<ActorDataOverview>
    {
    #region Public Variables

        [LabelText("資料棄用:")]
        [HorizontalGroup("ActorData")]
        [LabelWidth(55)]
        public bool Deactivate;

        [HorizontalGroup("ActorData")]
        [LabelWidth(22)]
        public int HP;

    #endregion
    }
}