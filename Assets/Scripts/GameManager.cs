using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Labels
    public Text CoinsLabel;
    public int Coins;
    public Text WaveLabel;
    private int wave;
    public Text HealtLevel;
    private int health;
    public GameObject[] HealthIndicator;

    public GameObject GameOverPanel;
    public GameObject WinMessagePanel;


    private bool gameOver;


    private const string COIN_LABEL_MASK = "Coins: {0}";
    private const string HEALTH_LABEL_MASK = "Health: {0}";
    private const string WAVE_LABEL_MASK = "Wave: {0}";


    // Singelton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(HealthIndicator.Length);
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoins();
        ShowHealth();
        ShowWave();
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;

        if (health <= 0 && !gameOver)
        {
            gameOver = true;
            Time.timeScale = 0.0f;
            GameOverPanel.SetActive(true);
        }

        for (int i = 0; i < HealthIndicator.Length; i++)
        {
            if (i < health)
            {
                HealthIndicator[i].SetActive(true);
            }
            else
            {
                HealthIndicator[i].SetActive(false);
            }
        }
    }

    public void SetWave(int wave)
    {
        this.wave = wave;
    }

    public int GetCoins()
    {
        return Coins;
    }

    public void SetCoins(int value)
    {
        Coins = value;
    }

    public void ShowCoins()
    {
        CoinsLabel.text = string.Format(COIN_LABEL_MASK, GetCoins());
    }

    public void ShowWave()
    {
        WaveLabel.text = string.Format(WAVE_LABEL_MASK, wave);
    }

    public void ShowHealth()
    {
        HealtLevel.text = string.Format(HEALTH_LABEL_MASK, health);
    }
}
