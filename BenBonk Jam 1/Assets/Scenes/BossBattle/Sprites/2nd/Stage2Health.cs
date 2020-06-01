using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Health : MonoBehaviour
{
    private int health = 14;
    public Animator anim;
    public GameObject boss;
    public GameObject hb;

    void Update()
    {
        if(health == 0){
              boss.GetComponent<SecondControl>().Death();
              hb.SetActive(false);
		}
    }

    public void TakeDamage(int damage){
        anim.SetInteger("secondHealth", health - damage);
        health = health - 1;
	}
}
