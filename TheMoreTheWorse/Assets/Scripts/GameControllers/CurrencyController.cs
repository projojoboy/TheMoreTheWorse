using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CurrencyController : MonoBehaviour {

    public int goldenCoins;
    public int purpleCoins;

    [SerializeField] Text purpleCoinText;
    [SerializeField] Text goldenCoinText;

	// Use this for initialization
	void Start () {
        PlayerPrefs.GetInt("GoldenCoins", goldenCoins);
        PlayerPrefs.GetInt("PurpleCoins", purpleCoins);

        purpleCoinText.text = "Coins: " + purpleCoins;
        goldenCoinText.text = "Coins: " + goldenCoins;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void AddPurpleCoins(int coinsToAdd)
    {
        purpleCoins += coinsToAdd;
        PlayerPrefs.SetInt("PurpleCoins", purpleCoins);
        purpleCoinText.text = "Coins: " + purpleCoins;
    }

    public void AddGoldenCoins(int coinsToAdd)
    {
        goldenCoins += coinsToAdd;
        PlayerPrefs.SetInt("GoldenCoins", goldenCoins);
        goldenCoinText.text = "Coins: " + goldenCoins;
    }
}
