using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowEnemy : MonoBehaviour
{

    private Transform target;

    public int moveSpeed = 4;
    public int maxDist = 10;
    public int minDist = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //transform.right = target.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

}
