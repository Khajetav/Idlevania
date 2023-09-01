using UnityEngine;

public class CombatScript : MonoBehaviour
{

    private HealthBar opponentHealth;
    private ScrollingTexture scrollingTexture;
    private EnemyMovementControllerScript enemyMovementController;
    private GameObject opponent;
    private AnimatorScript objectAnimator;

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
    }

    public void AttackOpponent(HealthBar opponentH, GameObject opponent)
    {
        opponentHealth = opponentH;
        this.opponent = opponent;
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
                //opponent.GetComponent<CombatScript>().PlayerDeath();
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
                // Enemy object gets deleted :0
                Destroy(opponent.gameObject);
            }
        }
    }
}
