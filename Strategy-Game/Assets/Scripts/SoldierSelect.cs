using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierSelect : MonoBehaviour
{
    private GameObject selectedGameObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                selectedGameObject = gameObject;
                gameObject.GetComponent<SoldierMovement>().enabled = true;
            }
        }
    }

}
