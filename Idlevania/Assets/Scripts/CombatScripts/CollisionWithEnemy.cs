using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                // player attacks the collision
                this.GetComponent<CombatScript>().AttackOpponent(collision.gameObject);
                // collision attacks the player
                collision.gameObject.GetComponent<CombatScript>().AttackOpponent(this.gameObject);
                GameManager.Instance.Pause();
                EnemyManager.Instance.playerContact = true;
                break;

            case "Loot":
                // Code to handle when switch_on is "loot"
                break;

            case "Obstacle":
                // Code to handle when switch_on is "obstacle"
                break;

            case "Trap":
                // Code to handle when switch_on is "trap"
                break;

            default:
                // Code to handle when switch_on doesn't match any of the above cases
                break;
        }
    }
}
