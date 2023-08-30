using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Enemy prefab config")]
    public List<GameObject> enemies;
    private EnemyMovementControllerScript emcs;
    [Header("Enemy spawn timer")]
    [SerializeField]
    private float spawnTimer = 0f;
    public float spawnInterval = 5f;

    private void Start()
    {
        emcs = GameObject.Find("CanvasMain").GetComponent<EnemyMovementControllerScript>();
    }

    private void Update()
    {
        if (!emcs.playerContact)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy(enemies[0]);
                spawnTimer = 0f;
            }
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        // Adds object to scene
        GameObject spawnedObject = Instantiate(enemy);
        // Moves object to EnemySpawnPoint in hierarchy as child
        spawnedObject.transform.parent = GameObject.Find("EnemySpawnPoint").transform;

        // Sets object position to 0
        spawnedObject.transform.localPosition = Vector3.zero;
        spawnedObject.transform.localRotation = Quaternion.identity;
        spawnedObject.transform.localScale = new Vector3(-1, 2.5f, 1);
        emcs.addEnemiesToListOnField(spawnedObject);
    }
}
