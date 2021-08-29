#region

using System.Reflection;
using UnityEditor;

#endregion

namespace OOOne.Tools.Editor
{
    public static class ClearConsoleLog
    {
    #region Private Methods

        [MenuItem("Tools/ClearLog %&c")]
        private static void ClearLog()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type     = assembly.GetType("UnityEditor.LogEntries");
            var method   = type.GetMethod("Clear");
            method.Invoke(new object() , null);
        }

    #endregion
    }
}