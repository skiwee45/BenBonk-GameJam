using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 10;
	public int currentHealth;
	public GameObject dieEffect;
	public Animator anim;

	public healthBar hb;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		hb.SetMaxHealth(maxHealth);
		hb.SetHealth(currentHealth);
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			FindObjectOfType<slingshotMovement>().drop();
			Destroy(gameObject);
			SceneManager.LoadScene("GameOver");
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		hb.SetHealth(currentHealth);
		anim.SetTrigger("Hurt");
	}
}
