using System;
using System.Diagnostics;
using UnityEngine;

namespace CustomInspector
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    [Conditional("UNITY_EDITOR")]
    public class FoldoutAttribute : PropertyAttribute
    {
        public FoldoutAttribute() => order = -6;
    }
}
