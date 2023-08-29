using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health bar config")]
    public Image healthFillImage;
    [Range(0, 100)]
    public int currentHealth = 100;
    private int maxHealth = 100;

    private void Start()
    {
        healthFillImage.fillAmount = maxHealth;
        currentHealth = maxHealth;
    }

    public void UpdateHealth(int damage)
    {
        if ((currentHealth - damage) >= 0)
        {
            currentHealth -= damage;
            healthFillImage.fillAmount =(float) currentHealth / maxHealth;
        }
        else
        {
            healthFillImage.fillAmount = 0;
        }
    }
}
