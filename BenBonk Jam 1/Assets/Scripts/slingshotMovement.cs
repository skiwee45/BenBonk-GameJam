using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshotMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Vector2 offset; //how far the slingshot is from the player
    public Vector2 mouse; //tracks mouse position
    public Camera cam;
    public float angle1; //angle from slingshot to mouse
    public bool flipped; //checks if slingshot is on right or left

    void Update()
    {
        mouse = cam.ScreenToWorldPoint(Input.mousePosition); //makes a vector 2 of the mouse position
        if (angle1 > 90 || angle1 < -90)
        {
            flipped = true;
            offset.x = -0.06f;
        }
        else {
            flipped = false;
            offset.x = 0.06f;
        }
    }
    void FixedUpdate() {
        rb.MovePosition(player.position + offset); //makes slingshot follow player

        Vector2 lookDir = mouse - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (flipped)
        {
            sr.flipY = true;
        }
        else {
            sr.flipY = false;
        }
        rb.rotation = angle;
        angle1 = angle;
    }

    public float getAngle() {
        return angle1;
    }
}