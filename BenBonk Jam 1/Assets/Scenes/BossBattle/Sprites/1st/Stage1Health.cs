using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Health : MonoBehaviour
{
    private int health = 14;
    public Animator anim;

    public void TakeDamage(int damage){
        anim.SetInteger("firstHealth", health - damage);
        health = health - 1;
        //Debug.Log("Boss has " + health + " health left.");
	}

}
