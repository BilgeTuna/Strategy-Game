using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 100f;
    //100-50
    public float currentHealth = 100f;
    public float damage = 10f;
    //
    private Vector2 screenPoint;
    private Vector2 offset;

    private GameObject panel;

    private void Start()
    {
        fillImage.fillAmount = 1f;
    }

    private void Update()
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }

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

    public void ReduceHealth(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
        }
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

        if (collision.gameObject.tag == "Bullet")
        {
            ReduceHealth(damage);
            if (currentHealth == 0f)
            {
                Destroy(gameObject);
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
