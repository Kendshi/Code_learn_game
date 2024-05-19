using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
    public class BE2_TargetObject : ResetBase, I_BE2_TargetObject
    {
        public Transform Transform => transform;
        public I_BE2_ProgrammingEnv ProgrammingEnv { get; set; }
    }
}