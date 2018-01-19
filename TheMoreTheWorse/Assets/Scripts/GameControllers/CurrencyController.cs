using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour {

    public int goldenCoins;
    public int purpleCoins;

	// Use this for initialization
	void Start () {
        PlayerPrefs.GetInt("GoldenCoins", goldenCoins);
        PlayerPrefs.GetInt("PurpleCoins", purpleCoins);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void AddPurpleCoins(int coinsToAdd)
    {
        purpleCoins += coinsToAdd;
        PlayerPrefs.SetInt("PurpleCoins", purpleCoins);
    }

    void AddGoldenCoins(int coinsToAdd)
    {
        goldenCoins += coinsToAdd;
        PlayerPrefs.SetInt("GoldenCoins", goldenCoins);
    }
}
