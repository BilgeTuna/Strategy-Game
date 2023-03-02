using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScan : MonoBehaviour
{
    private AstarPath astarPath;

    private void Update()
    {
        AstarPath.active.Scan();
    }
}
