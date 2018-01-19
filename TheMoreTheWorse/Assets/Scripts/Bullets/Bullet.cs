using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float destroyTime;
    [SerializeField] GameObject player;
    [SerializeField] int damage;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        Destroy(gameObject, destroyTime);
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        {
            coll.GetComponent<EnemyController>().RemoveHP(damage);
            Destroy(gameObject);
        }
    }
}
