using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health bar config")]
    public Image healthFillImage;
    [Range(0, 100)]
    public int currentHealth = 100;
    private int maxHealth = 100;

    public void UpdateHealth(int damage)
    {
        if ((currentHealth - damage) < 0)
        {
            healthFillImage.fillAmount = (currentHealth - damage) / maxHealth;
        }
        else
        {
            healthFillImage.fillAmount = 0;
        }
    }
    
}
