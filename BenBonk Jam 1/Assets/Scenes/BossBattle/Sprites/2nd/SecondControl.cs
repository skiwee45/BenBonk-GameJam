using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControl : MonoBehaviour
{
    public GameObject HealthBar;
    public Animator anim;
    public Rigidbody2D rb;
    public GameObject win;
    private bool isDead = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>(); 
	}

    void Update(){
        if(isDead == true){              
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

    public void GetDamage(int damage){
        HealthBar.GetComponent<Stage2Health>().TakeDamage(damage);
	}

    public void Death(){
        anim.SetTrigger("isDed");
        isDead = true;
        win.SetActive(true);
        HealthBar.SetActive(false);
    }

}
