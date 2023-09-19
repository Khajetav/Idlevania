using Unity.VisualScripting;
using UnityEngine;
public class CombatScript : MonoBehaviour
{

    private HealthBar opponentHealth;
    private GameObject opponent;
    private int currentOpponentHealth;
    private int maximumOpponentHealth;
    private Animator animator;

    private int damage;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void AttackOpponent(GameObject opponent)
    {
        opponentHealth = opponent.GetComponent<HealthBar>();
        this.opponent = opponent;
        if (opponent.CompareTag("Player"))
        {
            currentOpponentHealth = PlayerManager.Instance.currentPlayerHealth;
            maximumOpponentHealth = PlayerManager.Instance.maximumPlayerHealth;
            damage = this.GetComponent<EnemyConstructor>().damage;
            animator.SetTrigger("Attack");
        }
        else
        {
            maximumOpponentHealth = opponent.GetComponent<EnemyConstructor>().maximumEnemyHealth;
            currentOpponentHealth = maximumOpponentHealth;
            animator.SetBool("FightingIdle",true);
            damage = PlayerManager.Instance.damage;
        }
    }

    public void PlayerAttack()
    {
        DoDamage();
        opponentHealth.UpdateHealth((float)currentOpponentHealth / maximumOpponentHealth);
        // If opponents health drops to zero
        if (currentOpponentHealth == 0)
        {
            // Background scrolling resumes
            GameManager.Instance.Resume();
            // Enemies hovers towards player again
            EnemyManager.Instance.playerContact = false;
            // Removes enemy from list
            EnemyManager.Instance.RemoveDeadEnemyFromList();
            // Player stops Attacking Script
            animator.SetBool("FightingIdle", false);
            GameManager.Instance.UpdateXpAndMoneyText(opponent.GetComponent<EnemyConstructor>().score);
            // Enemy object gets deleted :0
            Destroy(opponent.gameObject); 
        }
    }
    public void EnemyAttack()
    {
        DoDamage();
        PlayerManager.Instance.currentPlayerHealth = currentOpponentHealth;
        opponentHealth.UpdateHealth((float)currentOpponentHealth / maximumOpponentHealth);
        if (currentOpponentHealth==0)
        {
            PlayerManager.Instance.PlayerDeathAnimation();
        }
        else
        {
            animator.SetTrigger("Attack");
        }
    }

    private void DoDamage()
    {
        currentOpponentHealth = currentOpponentHealth - damage;
        if (currentOpponentHealth < 0)
        {
            currentOpponentHealth = 0;
        }
    }
}
