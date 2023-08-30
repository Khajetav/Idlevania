using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject.Find("CanvasMain").GetComponent<ScrollingTexture>().isScrolling = false;
            GameObject.Find("CanvasMain").GetComponent<EnemyMovementControllerScript>().playerContact = true;   
            collision.gameObject.GetComponent<CombatScript>().AttackOpponent(this.gameObject.GetComponent<HealthBar>(), this.gameObject);
            this.gameObject.GetComponent<CombatScript>().AttackOpponent(collision.gameObject.GetComponent<HealthBar>(), collision.gameObject);
        }
    }
}
