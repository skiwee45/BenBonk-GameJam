using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class punch : MonoBehaviour
{
    public Transform firePoint; //where it shoots out from
    public GameObject bulletPrefab; //prefabbed ammo
    public float bulletForce = 1f;
    public Camera cam;
    public Rigidbody2D player;
    Vector2 mouse;
    bool throwPunch;
    public float attackRate = 1f;
    public float nextAttackTime;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            throwPunch = Input.GetButtonDown("Fire2"); //controls firing
            if (throwPunch)
            {
                Punch();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    void Punch()
    { //shooting function
        //creates and stores fist
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //stores fist rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //add force for fist to shoot out
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        //Makes fist face right way
        mouse = cam.ScreenToWorldPoint(Input.mousePosition); //makes a vector 2 of the mouse position
        Vector2 lookDir = mouse - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
        //destroy after 0.2 seconds
        Destroy(bullet, 0.13f);
        Debug.Log("Object Destroyed");
    }
}
