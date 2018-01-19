using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public int wave;
    public int amountMonSpawn;
    public int amountMonsTillNextWave = 5;

    private int bossWave;

    public bool spawnBoss;
    public bool spawnNextWave;

    [SerializeField] Text waveText;

	// Use this for initialization
	void Start () {
        wave = 1;
        amountMonSpawn = 5;
        bossWave = 5;
        spawnBoss = false;
	}
	
	// Update is called once per frame
	void Update () {
        AmountSpawnWave();
        waveText.text = "Wave: " + wave;
	}

    void AmountSpawnWave()
    {
        if(spawnNextWave == true)
        {
            amountMonsTillNextWave = amountMonSpawn;
        }

        if(wave == bossWave)
        {
            amountMonSpawn += 5;
            bossWave += 5;
        }

        if(amountMonsTillNextWave == 0)
        {
            StartCoroutine(WaitTillNextWave());
        }
    }

    IEnumerator WaitTillNextWave()
    {
        yield return new WaitForSeconds(3);
        spawnNextWave = true;
        wave++;
    }
}
