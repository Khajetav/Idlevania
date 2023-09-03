using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health bar config")]
    public Image healthFillImage;
    public int maxHealth;

    public void UpdateHealth(float currentHealth)
    {
        healthFillImage.fillAmount = currentHealth;
    }
}
