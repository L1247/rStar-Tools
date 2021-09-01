using System;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public class ActorName : NameBase
    {
        protected override IEnumerable GetNames()               => ActorDataOverview.GetActorNames();
        protected override bool        ValidateId(string value) => ActorDataOverview.IsStringContains(value);
    }
}