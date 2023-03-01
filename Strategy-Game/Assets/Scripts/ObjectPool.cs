using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject[] objects;
    private int maxSize;
    private int currentIndex = 0;

    public ObjectPool(GameObject prefab, int max, int size)
    {
        objects = new GameObject[size];
        maxSize = max;
        for (int i = 0; i < size; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            objects[i] = obj;
        }
    }

    public GameObject Spawn()
    {
        GameObject obj = objects[currentIndex];
        obj.SetActive(true);
        currentIndex = (currentIndex + 1) % maxSize;
        return obj;
    }

    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }
}
