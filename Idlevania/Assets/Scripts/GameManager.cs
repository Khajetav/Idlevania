using TMPro;
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
    [Range(0f, 1f)]
    public float globalSpeed = 0.075f;
    public float spawnTimer = 0f;
    public float spawnInterval = 5f;
    [Header("Player configs")]
    public int maximumPlayerHealth;
    public int damage;
    #endregion Variables
    [Header("Shop configuration")]
    public int money;
    public int playerXP;
    public GameObject shopPanel;
    public GameObject statsPanel;
    public TextMeshProUGUI moneyText;



    // Start makes it so that the enemy spawning logic and border scrolling are paused
    private void Start()
    {
        Pause();
        moneyText.text = money.ToString();
    }

    public void Resume()
    {
        scrollingTexture.enabled = true;
        EnemyManager.Instance.playerContact = false;
    }

    public void Pause()
    {
        scrollingTexture.enabled = false;
        EnemyManager.Instance.playerContact = true;
    }

    public void ShopInteraction()
    {
        if (!shopPanel.activeSelf)
        {
            Pause();
            shopPanel.SetActive(true);
            statsPanel.SetActive(false);
            PlayerManager.Instance.PlayerIdleAnimation();
        }
        else if (!statsPanel.activeSelf)
        {
            Resume();
            shopPanel.SetActive(false);
            statsPanel.SetActive(true);
            PlayerManager.Instance.StopPlayerIdleAnimation();
        }
    }

    public void UpdateXpAndMoneyText(int score)
    {
        money += score;
        playerXP+= score;
        moneyText.text = money.ToString();
    }
}