using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private AnimatorScript anim= new AnimatorScript();
    private void Awake()
    {
        anim.StartGameAnimation();
    }
}
