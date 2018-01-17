using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;

    public bool canShoot;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Shoot", true);
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                StartCoroutine(ShootAnim());
                StartCoroutine(FireRate());
                canShoot = false;
            }
        }
    }

    IEnumerator ShootAnim()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Shoot", false);
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
