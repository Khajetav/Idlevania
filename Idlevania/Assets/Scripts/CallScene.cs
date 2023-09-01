using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour
{
    public void CallNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
