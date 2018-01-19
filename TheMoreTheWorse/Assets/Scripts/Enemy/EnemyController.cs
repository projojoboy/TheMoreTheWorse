using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxHP;
    public float currentHP;
    public float damage;
    public float movementSpeed;

    [SerializeField] private bool specialMon;
    [SerializeField] private int amountGoldenCoins;
    [SerializeField] private int amountPurpleCoins;
    private GameObject player;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        Vector3 newScale = gameObject.transform.localScale;
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                movementSpeed = -movementSpeed;
            }

            if(player.transform.position.x > gameObject.transform.position.x)
            {
                newScale.x *= -1;
                gameObject.transform.localScale = newScale;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        Death();
    }

    public void RemoveHP(int removeHP)
    {
        currentHP -= removeHP;
    }

    void Death()
    {
        if(currentHP <= 0)
        {
            if (specialMon)
            {
                GameObject.Find("Canvas").GetComponent<CurrencyController>().AddGoldenCoins(amountGoldenCoins);
            }
            else if (!specialMon)
            {
                GameObject.Find("Canvas").GetComponent<CurrencyController>().AddPurpleCoins(amountPurpleCoins);
            }

            Destroy(gameObject);
        }
    }
}
