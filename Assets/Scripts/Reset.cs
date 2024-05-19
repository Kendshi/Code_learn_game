using System.Linq;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void ResetAll()
    {
        FindObjectsOfType<ResetBase>().ToList().ForEach(x => x.ResetObject());
    }
}
