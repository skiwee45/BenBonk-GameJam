using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceDirection : MonoBehaviour
{
    public Rigidbody2D rb;
    public slingshotMovement aim;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = aim.getAngle();
    }
}
