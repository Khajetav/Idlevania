using UnityEngine;

public class CombatScript : MonoBehaviour
{

    private HealthBar opponentHealth;
    private ScrollingTexture scrollingTexture;
    private EnemyMovementControllerScript enemyMovementController;
    private GameObject opponent;
    private AnimatorScript objectAnimator;

    [Header("Time config")]
    [SerializeField]
    private float attackTimer = 0f;
    public float attackInterval = 2f;
    private bool isAttacking = false;
    public float startAttackAnimation = 1.2f;
    [Header("Damage config")]
    public int damage = 10;

    private void Start()
    {
        GameObject canvasMain = GameObject.Find("CanvasMain");

        scrollingTexture = canvasMain.GetComponent<ScrollingTexture>();
        enemyMovementController = canvasMain.GetComponent<EnemyMovementControllerScript>();
        objectAnimator = this.gameObject.GetComponent<AnimatorScript>();
    }

    private bool isAnimating = false;

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            try
            {
                objectAnimator.FightingIdleAnimation();
            }
            catch
            {
                Debug.Log(string.Format("{0} doesn't have Idle Animation", this.gameObject.name));
            }
            // Animation starts a few milliseconds earlier
            if (attackTimer >= attackInterval / startAttackAnimation && !isAnimating)
            {
                isAnimating = true;
                try
                {
                    objectAnimator.FightingAnimation();
                }
                catch
                {
                    Debug.Log(string.Format("{0} doesn't have Fighting Animation", this.gameObject.name));
                }
            }
            if (attackTimer >= attackInterval)
            {
                isAnimating = false;
                attackTimer = 0f;
                Attack();
            }
        }
    }

    public void AttackOpponent(HealthBar opponentH, GameObject opponent)
    {
        isAttacking = true;
        opponentHealth = opponentH;
        this.opponent = opponent;
    }
    public void PlayerDeath()
    {
        isAttacking = false;
        objectAnimator.DeathAnimation();
    }
    public bool fighting()
    {
        return isAttacking;
    }

    public void Attack()
    {
        int currentHealth = opponentHealth.UpdateHealth(damage);
        // If opponents health drops to zero
        if (currentHealth == 0)
        {
            // And this opponent is player
            if (opponent.gameObject.CompareTag("Player"))
            {
                // GAME OVER!!!!
                Debug.Log("Game over!");
                // Player stops Attacking Script
                opponent.GetComponent<CombatScript>().PlayerDeath();
                isAttacking = false;
            }
            // And this opponent is Enemy
            else
            {
                // Background scrolling resumes
                scrollingTexture.isScrolling = true;
                // Enemies hovers towards player again
                enemyMovementController.playerContact = false;
                // Chck if this script is enabled (This is for not overide in shop idle animation)
                if (enemyMovementController.enabled)
                {
                    // Players starts walking animation
                    objectAnimator.WalkingAnimation();
                }
                else
                {
                    objectAnimator.StopFighting();
                }
                // Removes enemy from list. This could be deleted for later
                enemyMovementController.RemoveDeadEnemieFromList();
                // Player stops Attacking Script
                isAttacking = false;
                // Enemy object gets deleted :0
                Destroy(opponent.gameObject);
            }
        }
    }
}
