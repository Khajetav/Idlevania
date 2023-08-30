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
        objectAnimator.SetBool("Fighting", true);
    }
}
