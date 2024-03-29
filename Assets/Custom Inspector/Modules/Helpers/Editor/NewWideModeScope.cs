using System;
using UnityEditor;

namespace CustomInspector.Helpers.Editor
{
    public class NewWideModeScope : IDisposable
    {
        readonly bool wasWideMode;

        public NewWideModeScope(bool isWideMode)
        {
            wasWideMode = EditorGUIUtility.wideMode;
            EditorGUIUtility.wideMode = isWideMode;
        }

        void IDisposable.Dispose() => Dispose();
        public void Dispose()
        {
            EditorGUIUtility.wideMode = wasWideMode;
        }
    }
}
