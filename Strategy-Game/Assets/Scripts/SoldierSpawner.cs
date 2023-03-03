using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject prefabSoldier;
    public float[] spawnTimes;
    private int nextSpawnIndex = 0;
    private float timeElapsed = 0;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (nextSpawnIndex < spawnTimes.Length && timeElapsed > spawnTimes[nextSpawnIndex])
        {
            Instantiate(prefabSoldier, transform.position, transform.rotation);
            nextSpawnIndex++;
        }
    }
}
