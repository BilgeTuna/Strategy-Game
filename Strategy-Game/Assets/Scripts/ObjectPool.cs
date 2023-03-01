using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        pooledObjects= new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(objectPrefab);
            pooledObjects.Enqueue(gameObject);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject gameObject = pooledObjects.Dequeue();
        pooledObjects.Enqueue(gameObject);
        return gameObject;
    }
}
