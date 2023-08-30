using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    private HealthBar opponentHealth;
    public float attackInterval = 2f;

    private float attackTimer = 0f;
    private bool isAttacking = false;
    public int damage = 10;

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                //try
                //{
                //    this.gameObject.GetComponent<AnimatorScript>().FightingAnimation();
                //}
                //catch 
                //{
                //}
                
                attackTimer = 0f;
                opponentHealth.UpdateHealth(damage);
            }
        }
    }

    public void AttackOpponent(HealthBar opponentH)
    {
        isAttacking = true;
        opponentHealth = opponentH;
    }

}
