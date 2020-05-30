using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class shooting : MonoBehaviour
{
    public Transform firePoint; //where it shoots out from
    public GameObject bulletPrefab; //prefabbed ammo
    public float bulletForce = 1f;
    bool slingshot;

    // Update is called once per frame
    void Update()
    {
        slingshot = Input.GetButtonDown("Fire1"); //controls firing
        if (slingshot) {
            Shoot();
        }
    }

    void Shoot() { //shooting function
        //creates and stores bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //stores bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force to bullet to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
