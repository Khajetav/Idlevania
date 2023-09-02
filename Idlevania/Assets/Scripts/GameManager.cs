using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton code
    // reference the GameManager using GameManager.Instance
    #region Singleton code
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
    #region Variables
    [SerializeField] private ScrollingTexture scrollingTexture;
    [Space(10)]
    [Header("Global variables")]
    [Range(0f, 0.2f)]
    public float globalSpeed = 0.075f;
    public float spawnTimer = 0f;
    public float spawnInterval = 5f;
    #endregion Variables


    // Start makes it so that the enemy spawning logic and border scrolling are paused
    private void Start()
    {
        Pause();
    }

    // Character walking animation starts this
    //public void StartGameplay()
    //{
    //}
    public void Resume()
    {
        scrollingTexture.enabled = true;
    }

    public void Pause()
    {
        scrollingTexture.enabled = false;
    }
}