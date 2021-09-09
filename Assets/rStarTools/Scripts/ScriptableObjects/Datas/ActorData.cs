#region

using System;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using Sirenix.OdinInspector;

#endregion

namespace rStarTools.Scripts.ScriptableObjects.Datas
{
    [Serializable]
    public class ActorData : UniqueId<ActorDataOverview>
    {
    #region Public Variables

        [LabelText("資料棄用:")]
        [HorizontalGroup("UniqueId")]
        [LabelWidth(55)]
        public bool Deactivate;

        [HorizontalGroup("UniqueId")]
        [LabelWidth(22)]
        public int HP;

    #endregion
    }
}