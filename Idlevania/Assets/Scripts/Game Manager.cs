using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton code
    // reference the GameManager using GameManager.Instance
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField] private ScrollingTexture scrollingTexture;
    [SerializeField] private EnemyMovementControllerScript enemyMovementController;
    [SerializeField] private EnemySpawning enemySpawning;

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

    private void Start()
    {
        scrollingTexture.enabled = false;
        enemyMovementController.enabled = false;
        enemySpawning.enabled = false;
    }

    // Character walking animation starts this
    public void StartGameplay()
    {
    }
    public void Resume()
    {
        scrollingTexture.enabled = true;
        enemyMovementController.enabled = true;
        enemySpawning.enabled = true;
    }

    public void Pause()
    {
        scrollingTexture.enabled = false;
        enemyMovementController.enabled = false;
        enemySpawning.enabled = false;
    }
}