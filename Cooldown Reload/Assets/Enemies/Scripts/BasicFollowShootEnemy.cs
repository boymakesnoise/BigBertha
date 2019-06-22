using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowShootEnemy : MonoBehaviour
{

    private Transform target;
    private bool playerInRange;

    public Rigidbody2D bullet;
    public Transform firingPoint;

    public float nextFire;
    public float firingRate;

    public int moveSpeed = 4;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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


    void Update()
    {
        if (playerInRange == true)
            Shoot();

        if (playerInRange == false)
        {
            MoveToPlayer();
            Shoot();
        }
    }

    void MoveToPlayer()
    {
        //Attempt to create "LookAt" for Sprite
        //transform.right = target.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            Instantiate(bullet, firingPoint.position, firingPoint.rotation);
        }

    }
}
