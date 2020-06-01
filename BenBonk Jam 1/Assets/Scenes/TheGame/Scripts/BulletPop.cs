using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletPop : MonoBehaviour
{
    public GameObject hitEffect;
    //colliding script
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            Debug.Log("bullet damage hit");
        }
        else if (collision.gameObject.CompareTag("boss"))
        {
            collision.gameObject.GetComponent<SpawnFireball>().GetDamage(1);
            //Debug.Log("bullet damage hit on boss");
        }
        else if (collision.gameObject.CompareTag("boss2"))
        {
            collision.gameObject.GetComponent<SecondControl>().GetDamage(1);
            //Debug.Log("bullet damage hit on boss");
        }
        //particle effect and kills itself
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
