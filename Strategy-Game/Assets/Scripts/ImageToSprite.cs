using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ImageToSprite : MonoBehaviour
{
    private float mouserPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public GameObject prefab;

    public void Click()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(prefab, mousePos, Quaternion.identity);
        isBeingHeld= true;
    }

    private void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            prefab.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0f);
        }
    }
}
