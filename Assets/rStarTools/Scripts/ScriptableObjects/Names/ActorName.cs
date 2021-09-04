using System;
using System.Collections;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using rStarTools.Scripts.ScriptableObjects.Datas;
using ScriptableObjects;

namespace ScriptableObjects.Names
{
    [Serializable]
    public class ActorName : NameBase<ActorDataOverview,ActorData>
    {
        protected override string      LabelText                => "角色名稱";
        protected override ActorDataOverview GetDataOverview() => ActorDataOverview.Instance;
    }
}