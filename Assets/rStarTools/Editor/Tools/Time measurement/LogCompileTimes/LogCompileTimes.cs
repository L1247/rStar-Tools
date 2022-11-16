// Copyright 2021 by Hextant Studios. https://HextantStudios.com
// This work is licensed under CC BY 4.0. http://creativecommons.org/licenses/by/4.0/

#region

using System;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

#endregion

namespace Hextant.Editor
{
    // Logs the time taken to perform script compilations and domain reloads.
    public sealed class LogCompileTimes : EditorSingleton<LogCompileTimes>
    {
    #region Private Variables

        // The time (in ticks) when the script compilation started.
        private long _compilationStart;

        // The total time (in ticks) taken for script compilation.
        private long _compilationTime;

        // The time (in ticks) when the domain reload started.
        private long _reloadStart;

    #endregion

    #region Private Methods

        private void OnAfterAssemblyReload()
        {
            // Return if the assembly was reloaded before timers were started.
            if (_compilationTime == 0 || _reloadStart == 0) return;

            var compilation = new TimeSpan(_compilationTime);
            var reload      = new TimeSpan(DateTime.Now.Ticks - _reloadStart);
            Debug.Log($"Script compilation: {compilation.TotalSeconds:F3}s, " +
                      $"Domain reload: {reload.TotalSeconds:F3}s, "           +
                      $"Total: {(compilation + reload).TotalSeconds:F3}s ");
            _compilationTime = 0;
        }

        private void OnBeforeAssemblyReload()
        {
            _reloadStart = DateTime.Now.Ticks;
        }

        private void OnCompilationFinished(object value)
        {
            _compilationTime = DateTime.Now.Ticks - _compilationStart;
        }

        private void OnCompilationStarted(object value)
        {
            _compilationStart = DateTime.Now.Ticks;
        }

        private void OnDisable()
        {
            // Unregister for script compilation events.
            CompilationPipeline.compilationStarted  -= OnCompilationStarted;
            CompilationPipeline.compilationFinished -= OnCompilationFinished;

            // Unregister for domain reload events.
            AssemblyReloadEvents.beforeAssemblyReload -= OnBeforeAssemblyReload;
            AssemblyReloadEvents.afterAssemblyReload  -= OnAfterAssemblyReload;
        }

        private void OnEnable()
        {
            // Register for script compilation events.
            CompilationPipeline.compilationStarted  += OnCompilationStarted;
            CompilationPipeline.compilationFinished += OnCompilationFinished;

            // Register for domain reload events.
            AssemblyReloadEvents.beforeAssemblyReload += OnBeforeAssemblyReload;
            AssemblyReloadEvents.afterAssemblyReload  += OnAfterAssemblyReload;
        }

        [InitializeOnLoadMethod]
        private static void OnLoad()
        {
            Initialize();
        }

    #endregion
    }
}