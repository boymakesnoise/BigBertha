using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowEnemy : MonoBehaviour
{

    private Transform target;
    public SpriteRenderer sprite;
    public float health = 1;

    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        if (target.position.x > transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (target.position.x < transform.position.x)
        {
            sprite.flipX = false;
        }
    }

}
