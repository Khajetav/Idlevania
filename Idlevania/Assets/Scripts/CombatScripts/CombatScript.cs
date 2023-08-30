using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    
    private HealthBar opponentHealth;

    [Header("Time config")]
    [SerializeField]
    private float attackTimer = 0f;
    public float attackInterval = 2f;
    private bool isAttacking = false;
    [Header("Damage config")]
    public int damage = 10;

    private void Update()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            try
            {
                this.gameObject.GetComponent<AnimatorScript>().IdleAnimation();
            }
            catch
            {
                Debug.Log(string.Format("{0} doesn't have Idle Animation", this.gameObject.name));
            }
           
            if (attackTimer >= attackInterval)
            {
                try
                {
                    this.gameObject.GetComponent<AnimatorScript>().FightingAnimation();
                }
                catch
                {
                    Debug.Log(string.Format("{0} doesn't have Fighting Animation",this.gameObject.name));
                }

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
