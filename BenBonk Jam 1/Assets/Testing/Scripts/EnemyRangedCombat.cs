using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class EnemyRangedCombat : MonoBehaviour
{
    public float speed = 2f;
    public float stopDistance;
    public Transform player;
    public EnemyAI enemyMovement;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;
    private void Start()
    {
        //makes player transform to lock onto
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //sets up ai movement
        enemyMovement = GetComponent<EnemyAI>();
        enemyMovement.enabled = false;
        //sets current bullet reload to shooting rate
        timeBetweenShots = startTimeBetweenShots;
    }
    private void Update()
    {
        //takes care of movement
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            //move towards player (use the ai script)
            enemyMovement.enabled = true;
        } else if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            transform.position = this.transform.position; //stop moving
            enemyMovement.enabled = false; //disables ai movement
        } else
        {
            enemyMovement.enabled = false; //disables ai movement
        }

        //shooting if statements
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
