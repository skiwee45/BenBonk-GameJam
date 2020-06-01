using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            //Debug.Log("Player hit!");
            other.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
	}
}
