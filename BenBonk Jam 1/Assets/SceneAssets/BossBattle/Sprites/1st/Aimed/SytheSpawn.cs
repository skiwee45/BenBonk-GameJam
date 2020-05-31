using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SytheSpawn : MonoBehaviour
{
    
    public GameObject player;
    public GameObject scythe;
    public Rigidbody2D rb;

    public Vector2 playerPos;

    void Update()
    {
        playerPos = player.transform.position;
    }

    void FixedUpdate(){
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
	}
}
