
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    Transform target;
    public float speed = 20f;
    public float nextWaypointDistance = 0.2f;

    Path path;
    int currentWaypoint;
    bool reachEnd = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if path is there
        if (path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachEnd = true;
            return;
        } else
        {
            reachEnd = false;
        }
        //creates direction and force
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);//adds force
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);//how far from next waypoint

        //checks if waypoint reached
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnPathComplete (Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public bool getReachedEnd()
    {
        return reachEnd;
    }
}
