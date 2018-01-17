using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxHP;
    public float currentHP;
    public float damage;
    public float movementSpeed;

    private GameObject player;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                movementSpeed = -movementSpeed;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

        if(currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveHP(int removeHP)
    {
        currentHP -= removeHP;
    }
}
