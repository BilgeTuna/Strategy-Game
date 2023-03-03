using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 100f;
    public float currentHealth = 10f;
    public float damage = 10f;

    public GameObject bulletPrefab;
    //10f - 5f- 2f
    public float bulletSpeed;
    private Camera mainCamera;

    void Start()
    {
        fillImage.fillAmount = 1f;
        mainCamera = Camera.main;
    }

    void Update()
    {
        fillImage.fillAmount = currentHealth / maxHealth; 

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Shoot(hit.point);
            }
        }
    }

    void Shoot(Vector2 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            gameObject.GetComponent<Animator>().SetBool("isAttack", true);
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            bulletRb.velocity = direction * bulletSpeed;
        }
    }

    public void ReduceHealth(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
        }
    }

    IEnumerator DeadAnim()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ReduceHealth(damage);
            if (currentHealth == 0f)
            {
                gameObject.GetComponent<Animator>().SetBool("isAttack", false);
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
                StartCoroutine(DeadAnim());
            }
        }
    }
}
