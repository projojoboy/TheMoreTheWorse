using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    public bool left;
    public bool right;
    public bool isGrounded;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "GroundCheck")
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * h, rb.velocity.y);

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
    }
}
