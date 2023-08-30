using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{
    private EnemyMovementControllerScript m_EnemyMovementControllerScript;

    private void Start()
    {
        m_EnemyMovementControllerScript = GameObject.Find("CanvasMain").GetComponent<EnemyMovementControllerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_EnemyMovementControllerScript.playerContact = true;
            collision.gameObject.GetComponent<AnimatorScript>().FightingAnimation();
        }
    }
}
