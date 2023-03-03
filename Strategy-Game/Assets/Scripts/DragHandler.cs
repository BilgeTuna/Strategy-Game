using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour
{
    private Vector2 screenPoint;
    private Vector2 offset;

    public Pane
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panelText;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition = (Vector2)Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    public void ButtonEffect()
    {
        panelText.SetActive(true);
        panel1.SetActive(true);
    }

    public void ButtonEffect2()
    {
        panelText.SetActive(true);
        panel2.SetActive(true);
    }

    public void ButtonEffect3()
    {
        panelText.SetActive(true);
        panel3.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Areas")
        {
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
