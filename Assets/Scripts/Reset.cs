using System.Linq;
using MG_BlocksEngine2.Core;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void ResetAll()
    {
        BE2_ExecutionManager.Instance.Stop();
        FindObjectsOfType<ResetBase>().ToList().ForEach(x => x.ResetObject());
    }
}
