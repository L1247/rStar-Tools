using Sirenix.Utilities.Editor;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorDataOverview" , menuName = "rStar/ActorDataOverview" , order = 0)]
    public class ActorDataOverview : DataOverviewBase<ActorDataOverview , ActorData> { }
}