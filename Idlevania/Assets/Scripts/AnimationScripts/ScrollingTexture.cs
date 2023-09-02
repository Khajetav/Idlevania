using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    [Header("Background Settings")]
    [SerializeField] private List<Transform> backgroundList;
    private float scrollSpeed;
    private Vector2 leftSide;
    private Vector2 rightSide;

    private void Start()
    {
        scrollSpeed = GameManager.Instance.globalSpeed;
        leftSide = backgroundList[2].position;
        rightSide = backgroundList[1].position;
    }

    private void Update()
    {
        foreach (var background in backgroundList)
        {
            background.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
            if (background.position.x <= leftSide.x)
            {
                background.position = rightSide;
            }
        }
    }
}
