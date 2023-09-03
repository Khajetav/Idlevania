using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Singleton code for EnemyController
    #region singleton
    private static EnemyManager _instance;
    public static EnemyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemyManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region variables
    public float spawnInterval;
    public float spawnTimer;
    public bool playerContact;
    public float movementSpeed;
    Vector3 characterPosition;
    // list of all enemies that we have
    public List<GameObject> enemyBeastiaryList = new List<GameObject>();
    // list of all enemies that are currently on the scene
    public List<GameObject> aliveEnemyList = new List<GameObject>();
    #endregion variables

    private void Start()
    {
        movementSpeed = GameManager.Instance.globalSpeed;
        spawnTimer = GameManager.Instance.spawnTimer;
        spawnInterval = GameManager.Instance.spawnInterval;
        characterPosition = GameObject.Find("Character").transform.position;
    }

    private void Update()
    {
        if (!playerContact)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy(enemyBeastiaryList[0]);
                spawnTimer = 0f;
            }
            foreach (var enemy in aliveEnemyList)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, characterPosition, movementSpeed * Time.deltaTime);
            }
        }
    }


    // Example function for spawning enemies
    private void SpawnEnemy(GameObject enemy)
    {
        // Adds object to scene
        GameObject spawnedObject = Instantiate(enemy);
        // Moves object to EnemySpawnPoint in hierarchy as child
        spawnedObject.transform.parent = GameObject.Find("EnemySpawnPoint").transform;

        // Sets object position to 0
        spawnedObject.transform.localPosition = Vector3.zero;
        spawnedObject.transform.localRotation = Quaternion.identity;
        spawnedObject.transform.localScale = new Vector3(-2, 2.5f, 1);
        AddEnemiesToListOnField(spawnedObject);
    }

    public void AddEnemiesToListOnField(GameObject enemy)
    {
        aliveEnemyList.Add(enemy);
    }
    public void RemoveDeadEnemyFromList()
    {
        aliveEnemyList.RemoveAt(0);
    }
}