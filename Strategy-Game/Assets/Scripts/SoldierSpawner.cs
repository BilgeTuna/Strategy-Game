using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float[] spawnTimes;
    private int nextSpawnIndex = 0;
    private float timeElapsed = 0;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (nextSpawnIndex < spawnTimes.Length && timeElapsed > spawnTimes[nextSpawnIndex])
        {
            Instantiate(prefab, transform.position, transform.rotation);
            nextSpawnIndex++;
        }
    }
}
