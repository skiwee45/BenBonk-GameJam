using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Combat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    public float attackRate = 1f;
    float nextAttackTime;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (GetComponent<EnemyAI>().getReachedEnd())
            {
                Attack();
                Debug.Log("Enemy Attack");
                nextAttackTime = Time.time + attackRate;
            }
        }
    }
    void Attack()
    {
        //play animation
        anim.SetTrigger("isAttacking");
        //detect player in attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        //deal damage
        foreach(Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1);
            Debug.Log("We Hit" + player.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
