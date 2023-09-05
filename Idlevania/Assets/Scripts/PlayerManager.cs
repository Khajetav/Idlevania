using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton code
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerManager>();
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

    public int currentPlayerHealth;
    public int maximumPlayerHealth;
    public int damage;
    public Animator playerAnimator;

    [Header("Player sprite replacement with revive sprite")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Sprite playerReviveSprite;

    private void Start()
    {
        // Plays revive animation if player has died
        if (PlayerPrefs.GetInt("PlayerDied") ==1)
        {
            PlayerPrefs.SetInt("PlayerDied", 0);
            playerAnimator.SetTrigger("Revive");
            playerSprite.sprite = playerReviveSprite;
        }
        maximumPlayerHealth = GameManager.Instance.maximumPlayerHealth;
        damage = GameManager.Instance.damage;
        currentPlayerHealth = maximumPlayerHealth;
    }

    public void PlayerDeathAnimation()
    {
        playerAnimator.SetTrigger("Death");
    }
    public void PlayerIdleAnimation()
    {
        playerAnimator.SetBool("Idle", true);
    }
    public void StopPlayerIdleAnimation()
    {
        playerAnimator.SetBool("Idle", false);
    }
}
