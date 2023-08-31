using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    private AnimatorScript cAnimation;

    private void Start()
    {
        cAnimation = GameObject.Find("Character").GetComponent<AnimatorScript>();
    }

    public void OpenShop()
    {
        EnemyMovementControllerScript emcs = GameObject.Find("CanvasMain").GetComponent<EnemyMovementControllerScript>();
        emcs.enabled = !emcs.enabled;
        ScrollingTexture scrolling = GameObject.Find("CanvasMain").GetComponent<ScrollingTexture>();
        scrolling.enabled = !scrolling.enabled;
        EnemySpawning spawning = GameObject.Find("CanvasMain").GetComponent<EnemySpawning>();
        spawning.enabled = !spawning.enabled;
        if (!spawning.enabled)
        {
            cAnimation.IdleAnimation();
        }
        else
        {
            cAnimation.WalkingAnimation();
        }
    }
}
