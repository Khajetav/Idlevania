using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingTexture : MonoBehaviour
{
    [Header("Background Settings")]
    [Range(0f, 0.2f)]
    public float scrollSpeed = 0.075f;
    public bool isScrolling = true; // Change this based on your control logic
    public RawImage background;

    private void Update()
    {
        if (isScrolling)
        {
            background.uvRect = new Rect(background.uvRect.position + new Vector2(scrollSpeed, 0) * Time.deltaTime, background.uvRect.size);
        }
    }
}
