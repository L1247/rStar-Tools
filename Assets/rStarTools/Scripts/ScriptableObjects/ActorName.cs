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
        protected override IEnumerable GetNames()               => ActorDataOverview.Instance.GetNames();
        protected override bool        ValidateId(string value) => ActorDataOverview.Instance.IsStringContains(value);
    }
}