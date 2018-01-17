using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHP;
    public float currentHP;

    private float tempRemoveHP;

    [SerializeField] Text textHP;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentHP <= 0)
        {
            Death();
        }

        textHP.text = "Health: " + currentHP;
	}

    public void RemoveHP(float HealthToBeRemoved)
    {
        currentHP -= HealthToBeRemoved;
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        {
            tempRemoveHP = coll.GetComponent<EnemyController>().damage;
            RemoveHP(tempRemoveHP);
            Destroy(coll.gameObject);
        }
    }
}
