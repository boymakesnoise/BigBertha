using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowShootEnemy : MonoBehaviour
{
    private Transform target;
    private bool playerInRange;

    public GameObject bullet;
    public Transform firingPoint;

    public float nextFire;
    public float firingRate;

    public int moveSpeed = 4;
    public float health = 1;

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

    void LookAtPlayer()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90);
    }

    void MoveToPlayer()
    {
        LookAtPlayer();
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
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
}
