using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject Enemy;

    private float spawnDelay;
    private bool spawn;

	// Use this for initialization
	void Start () {
        spawn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawn)
        {
            spawnDelay = Random.Range(1f, 3f);
            Instantiate(Enemy, transform.position, transform.rotation);
            spawn = false;
            StartCoroutine(SpawnEnemy());
        }
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        spawn = true;
    }
}
