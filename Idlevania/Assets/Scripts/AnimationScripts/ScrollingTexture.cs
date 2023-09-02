using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingTexture : MonoBehaviour
{
    [Header("Background Settings")]
    public float scrollSpeed;
    public RawImage background;
    private void Start()
    {
        // GameManager should be called only from Start or similar
        scrollSpeed = GameManager.Instance.globalSpeed;
    }
    private void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(scrollSpeed, 0) * Time.deltaTime, background.uvRect.size);
    }
}
