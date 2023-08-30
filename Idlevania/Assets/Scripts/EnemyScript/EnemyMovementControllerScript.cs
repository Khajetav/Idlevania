using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementControllerScript : MonoBehaviour
{
    [Header("Enemy movement settings")]
    [SerializeField]
    private List<Transform> enemiesOnField;
    [Range(0, 2f)]
    public float movementSpeed = 0.075f;

    public bool playerContact = false;
    private Vector3 characterPosition;

    private void Start()
    {
        characterPosition = GameObject.Find("Character").transform.position;
    }

    private void Update()
    {
        if (playerContact)
        {
            Debug.Log("Enemy collided with player!");
        }
        else
        {
            foreach (var item in enemiesOnField)
            {
                item.transform.position = Vector3.MoveTowards(item.transform.position, characterPosition, movementSpeed * Time.deltaTime);
            }
        }
    }
}
