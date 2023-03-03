using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    void Start()
    {
        fillImage.fillAmount = 1f;
    }

    void Update()
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }

    public void ReduceHealth(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0f)
        {
            currentHealth = 0f;
        }
    }
}
