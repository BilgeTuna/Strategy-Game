using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageToSprite : MonoBehaviour
{
    public GameObject prefab;
    public void Button()
    {
        Vector3 prefabPos = new Vector3(0, 0, 0);
        Instantiate(prefab, prefabPos, Quaternion.identity);
    }
}
