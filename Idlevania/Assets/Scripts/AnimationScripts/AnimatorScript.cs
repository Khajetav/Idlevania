using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class AnimatorScript : MonoBehaviour
{
    private Animator objectAnimator;
    private CallScene scene = new CallScene();

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

    public void ReviveEndAnimantion()
    {
        GameObject canvasMain = GameObject.Find("CanvasMain");
        canvasMain.GetComponent<ScrollingTexture>().enabled = true;
        canvasMain.GetComponent<EnemyMovementControllerScript>().enabled = true;
        canvasMain.GetComponent<EnemySpawning>().enabled = true;
    }

    public void StartNewScene()
    {
        scene.CallNewScene("SceneMain");
    }

    public void StartGameAnimation()
    {
        GameObject.Find("ImageBlackout").GetComponent<Animator>().SetTrigger("Blackin");
    }
}
