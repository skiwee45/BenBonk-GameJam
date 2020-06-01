using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControl : MonoBehaviour
{
    public GameObject HealthBar;
    public Animator anim;
    public Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
	}

    public void GetDamage(int damage){
        HealthBar.GetComponent<Stage2Health>().TakeDamage(damage);
	}

    public void Death(){
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetTrigger("isDed");
	}

}
