using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator objectAnimator;

    void Start()
    {
        objectAnimator = this.GetComponent<Animator>();
    }

    public void FightingAnimation()
    {
        objectAnimator.SetTrigger("Fighting");
    }

    public void IdleAnimation()
    {
        objectAnimator.SetBool("Idle", true);
    }

    public void WalkingAnimation()
    {
        objectAnimator.SetBool("FightingIdle", false);
        objectAnimator.SetBool("Idle", false);
    }

    public void StopFighting()
    {
        objectAnimator.SetBool("FightingIdle", false);
    }

    public void DeathAnimation()
    {
        GameObject.Find("ImageBorder").GetComponent<Animator>().SetTrigger("Death");
        GameObject.Find("ImageBlackout").GetComponent<Animator>().SetTrigger("Blackout");
        objectAnimator.SetTrigger("Death");
    }

    public void FightingIdleAnimation()
    {
        objectAnimator.SetBool("FightingIdle", true);
    }
}
