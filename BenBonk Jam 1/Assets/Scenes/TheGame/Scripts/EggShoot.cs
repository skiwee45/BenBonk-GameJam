using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EggShoot : MonoBehaviour
{
    public float speed = 1f;
    public Transform player;
    public Vector2 target;
    public GameObject hitEffect;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //finds player transform
        target = new Vector2(player.position.x, player.position.y); //gets position
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //shoot towards target
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(1);
            Debug.Log("egg hit");
            DestroyProjectile();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile ()
    {
        //particle effect and kills itself
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
