using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth = 2;
	public int currentHealth;
	public GameObject dieEffect;


	// Start is called before the first frame update
	void Start()
	{
		currentHealth = 2;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		Debug.Log("damage taken");
	}
}
