using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;
    public Animator anim;

    Vector2 movement;

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x == -1 || movement.x == 1 || movement.y == -1 || movement.y == 1){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);  
		}
        
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

}
