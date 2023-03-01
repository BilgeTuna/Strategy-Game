using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] public int poolSize;

    public void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(objectPrefab);
            gameObject.SetActive(false);
            pooledObjects.Enqueue(gameObject);
        }
    }

    public GameObject GetDeleteIt()
    { 
        return pooledObjects.Dequeue();
    }

    public GameObject GetPooledObject()
    {
        GameObject gameObject = pooledObjects.Dequeue();
        gameObject.SetActive(true);
        pooledObjects.Enqueue(gameObject);
        return gameObject;
    }
}
