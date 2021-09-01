using EditorUtilities;
using UnityEngine;

namespace rStarTools.Scripts.ScriptableObjects.BaseClasses
{
    public class SingletonScriptableObject<T> : ScriptableObject where T: ScriptableObject
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null) instance = CustomEditorUtility.GetScriptableObject<T>();
                return instance;
            }
        }
    }
}