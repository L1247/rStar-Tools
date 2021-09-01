using System;
using System.Collections;
using rStarTools.Scripts.ScriptableObjects.BaseClasses;
using rStarTools.Scripts.ScriptableObjects.DataOverviews;
using ScriptableObjects;

namespace ScriptableObjects.Names
{
    [Serializable]
    public class ActorName : NameBase
    {
        protected override IEnumerable GetNames()               => ActorDataOverview.Instance.GetNames();
        protected override bool        ValidateId(string value) => ActorDataOverview.Instance.IsStringContains(value);
    }
}