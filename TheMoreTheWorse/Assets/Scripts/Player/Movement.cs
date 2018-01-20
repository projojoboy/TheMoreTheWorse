using System;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] int _playerNumber = 1;

    public bool left;
    public bool right;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        //float h = Input.GetAxis("Horizontal");
        float h = -(Convert.ToInt32(InputController.GetInput.Left(_playerNumber)) - Convert.ToInt32(InputController.GetInput.Right(_playerNumber)));

        rb.velocity = new Vector2(speed * h, rb.velocity.y);

        if (InputController.GetInput.Left(_playerNumber) || InputController.GetInput.Right(_playerNumber))
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);

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
