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
            Debug.LogError($"There has Error: {message}");
        }

        public void RunFinished(ITestResultAdaptor result)
        {
            runTestTime = DateTime.Now.Ticks - runStart;
            var totalTestTime    = new TimeSpan(runTestTime);
            var failCountMessage = result.FailCount > 0 ? $"<color=red>{result.FailCount}</color>." : result.FailCount.ToString();
            var failMessage      = $"Failed test count: {failCountMessage}";
            Debug.Log($"Test duration: <color=#00afb9>{result.Duration}(s)</color> , "
                    + $"Total time: <color=#5995ed>{totalTestTime.TotalSeconds:F3}(s)</color>.\n"
                    + $"               Passed test count: <color=#0BAB33>{result.PassCount}</color> ,       "
                    + failMessage);
            runTestTime = 0;
        }

        public void RunStarted(ITestAdaptor testsToRun)
        {
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
        var instances     = Resources.FindObjectsOfTypeAll<TestRunnerApi>();
        var testRunnerApi = instances[0];
        testRunnerApi.RegisterCallbacks(new TestCallbacks());
    }

#endregion
}