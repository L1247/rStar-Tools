using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.Datas;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.DataOverviews
{
    [CreateAssetMenu(fileName = "ActorDataOverview" , menuName = "rStar/ActorDataOverview" , order = 0)]
    public class ActorDataOverview : DataOverviewBase<ActorDataOverview , ActorData> { }
}