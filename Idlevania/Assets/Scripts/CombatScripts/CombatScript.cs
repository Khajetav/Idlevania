using UnityEngine;
public class CombatScript : MonoBehaviour
{

    private HealthBar opponentHealth;
    private ScrollingTexture scrollingTexture;
    private EnemyManager enemyManager;
    private GameObject opponent;

    [Header("Damage config")]
    public int damage = 10;

    public void AttackOpponent(GameObject opponent)
    {
        opponentHealth = opponent.GetComponent<HealthBar>();
        this.opponent = opponent;
    }

    public void PlayerAttack()
    {
        int currentHealth = opponentHealth.UpdateHealth(damage);
        // If opponents health drops to zero
        if (currentHealth == 0)
        {
            // Background scrolling resumes
            GameManager.Instance.Resume();
            // Enemies hovers towards player again
            EnemyManager.Instance.playerContact = false;
            // Removes enemy from list. This could be deleted for later
            EnemyManager.Instance.RemoveDeadEnemyFromList();
            // Player stops Attacking Script
            // Enemy object gets deleted :0
            Destroy(opponent.gameObject);
        }
    }
    public void EnemyAttack()
    {
        int currentHealth = opponentHealth.UpdateHealth(damage);
    }
}
