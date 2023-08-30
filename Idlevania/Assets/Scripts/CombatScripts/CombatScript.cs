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
    [Header("Damage config")]
    public int damage = 10;

    private void Start()
    {
        GameObject canvasMain = GameObject.Find("CanvasMain");

        scrollingTexture = canvasMain.GetComponent<ScrollingTexture>();
        enemyMovementController = canvasMain.GetComponent<EnemyMovementControllerScript>();
        objectAnimator = this.gameObject.GetComponent<AnimatorScript>();
    }

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            try
            {
                objectAnimator.IdleAnimation();
            }
            catch
            {
                Debug.Log(string.Format("{0} doesn't have Idle Animation", this.gameObject.name));
            }

            if (attackTimer >= attackInterval)
            {
                try
                {
                    objectAnimator.FightingAnimation();
                }
                catch
                {
                    Debug.Log(string.Format("{0} doesn't have Fighting Animation", this.gameObject.name));
                }

                attackTimer = 0f;
                // returns opponent current health
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
                        // Players starts walking animation
                        objectAnimator.WalkingAnimation();
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
}
