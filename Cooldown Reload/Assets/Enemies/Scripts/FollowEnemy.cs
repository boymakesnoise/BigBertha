using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowEnemy : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public SpriteRenderer sprite;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private int SpawnerID;
    private GameObject objSpawn;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // this gets called in the beginning when it is created by the spawner script
    void setName(int sName)
    {
        SpawnerID = sName;
    }

    // Call this when you want to kill the enemy
    void removeMe()
    {
        objSpawn.BroadcastMessage("killEnemy", SpawnerID);
        Destroy(gameObject);
    }


    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (target.position.x > transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (target.position.x < transform.position.x)
        {
            sprite.flipX = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }
}
