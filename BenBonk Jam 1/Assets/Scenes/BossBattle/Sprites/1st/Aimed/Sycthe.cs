using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sycthe : MonoBehaviour
{
	public GameObject hitEffect;

	private void OnTriggerEnter2D(Collider2D other){

         if (other.gameObject.CompareTag("Player")) {
            //Debug.Log("Player is hit with scythe!");
            other.GetComponent<PlayerHealth>().TakeDamage(1);
         }
		 GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);

	}

}
