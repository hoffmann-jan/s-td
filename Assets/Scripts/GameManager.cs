using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text CoinsLabel;
    public int Coins;

    private const string COIN_LABEL_MASK = "Coins: {0}";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoins();
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
        CoinsLabel.GetComponent<Text>().text = string.Format(COIN_LABEL_MASK, GetCoins());
    }
}
