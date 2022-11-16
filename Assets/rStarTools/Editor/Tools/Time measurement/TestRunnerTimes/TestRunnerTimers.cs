#region

using System;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

#endregion

public sealed class TestRunnerTimers /*: EditorSingleton<TestRunnerTimers>*/
{
#region Private Variables

    private class TestCallbacks : IErrorCallbacks
    {
    #region Private Variables

        private long runStart;
        private long runTestTime;

    #endregion

    #region Public Methods

        public void OnError(string message)
        {
            Debug.Log(message);
        }

        public void RunFinished(ITestResultAdaptor result)
        {
            runTestTime = DateTime.Now.Ticks - runStart;
            var compilation = new TimeSpan(runTestTime);
            Debug.Log($"Test run time: {compilation.TotalSeconds:F3}s ," +
                      $"Test duration: {result.Duration}s");
            runTestTime = 0;
        }

        public void RunStarted(ITestAdaptor testsToRun)
        {
            // Debug.Log("Tests started");
            runStart = DateTime.Now.Ticks;
        }

        public void TestFinished(ITestResultAdaptor result) { }

        public void TestStarted(ITestAdaptor test) { }

    #endregion
    }

#endregion

#region Private Methods

    [InitializeOnLoadMethod]
    private static void OnLoad()
    {
        // Initialize();

        // Find the existing instance or creates a new one.
        var instances     = Resources.FindObjectsOfTypeAll<TestRunnerApi>();
        var testRunnerApi = instances[0];
        testRunnerApi.RegisterCallbacks(new TestCallbacks());
    }

#endregion
}