using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private Vector2 screenPoint;
    private Vector2 offset;
    private GameObject soldier;
    private Animator anim;

    private void Awake()
    {
        soldier = GameObject.FindWithTag("Soldier");
        anim = soldier.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        soldier.GetComponent<SoldierMovement>().enabled= false;
        anim.SetBool("isWalinkg", false);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        //soldier.GetComponent<SoldierMovement>().enabled = true;
        Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition = (Vector2)Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    private void OnMouseUp()
    {
        anim.SetBool("isWalinkg", true);
        soldier.GetComponent<SoldierMovement>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Areas")
        {
            Debug.Log("1453");
            foreach (Transform child in collision.gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Areas")
        {
            foreach (Transform child in collision.gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
