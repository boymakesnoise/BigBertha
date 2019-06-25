using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowShootEnemy : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public SpriteRenderer sprite;

    private bool playerInRange;

    public GameObject bullet;
    public Transform firingPoint;

    public float nextFire;
    public float firingRate;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;



    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerInRange = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerInRange = false;
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

    void LookAtPlayer()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90);
    }

    void Shoot()
    {
        LookAtPlayer();

        if (Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            Instantiate(bullet, firingPoint.position, firingPoint.rotation);
        }

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

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (playerInRange == true)
            Shoot();

        if (playerInRange == false)
        {
            Shoot();
        }

    }
}
