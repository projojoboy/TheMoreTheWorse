using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] GameObject shootPointShotgun;
    [SerializeField] GameObject shootPointRifles;
    [SerializeField] GameObject shotgunBullet;
    [SerializeField] GameObject assaultBullet;
    [SerializeField] private int _player = 1;

    private float fireRate;

    private GameObject equippedBullet;

    private int equippedWeapon;

    public bool canShoot;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;

        equippedWeapon = 1;
    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
        WeaponSwapping();
	}

    void Shoot()
    {
        if (canShoot)
        {
            if (InputController.GetInput.Shoot(_player))
            {
                rb.velocity = Vector3.zero;
                anim.SetBool("Shoot", true);

                if(equippedWeapon == 1)
                    Instantiate(equippedBullet, shootPointRifles.transform.position, shootPointRifles.transform.rotation);
                else if(equippedWeapon == 2)
                    Instantiate(equippedBullet, shootPointShotgun.transform.position, shootPointShotgun.transform.rotation);

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

    void WeaponSwapping()
    {
        if (InputController.GetInput.Weapon1(_player))
            equippedWeapon = 1;
        else if (InputController.GetInput.Weapon2(_player))
            equippedWeapon = 2;

        switch (equippedWeapon)
        {
            case 1:
                equippedBullet = assaultBullet;
                fireRate = 0.2f;
                break;
            case 2:
                equippedBullet = shotgunBullet;
                fireRate = 0.5f;
                break;
        }
    }
}
