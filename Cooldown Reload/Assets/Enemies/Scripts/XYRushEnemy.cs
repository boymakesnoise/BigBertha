using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class XYRushEnemy : MonoBehaviour
{
    private GameObject player;

    private Transform enemyPos;
    public float rayLength = 10f;

    private Vector2 directionRight;
    private Vector2 directionLeft;
    private Vector2 directionUp;
    private Vector2 directionDown;

    public void Start()
    {
        player = GameObject.Find("Player");

        enemyPos = this.gameObject.transform;
        directionRight = Vector2.right;
        directionLeft = Vector2.left;
        directionUp = Vector2.up;
        directionDown = Vector2.down;
    }

    public void Update()
    {
        RaycastHit2D rightInfo = Physics2D.Raycast(enemyPos.position, directionRight * rayLength);
        Debug.DrawRay(enemyPos.position, directionRight * rayLength, Color.green);

        RaycastHit2D leftInfo = Physics2D.Raycast(enemyPos.position, directionLeft * rayLength);
        Debug.DrawRay(enemyPos.position, directionLeft * rayLength, Color.green);

        RaycastHit2D upInfo = Physics2D.Raycast(enemyPos.position, directionUp * rayLength);
        Debug.DrawRay(enemyPos.position, directionUp * rayLength, Color.green);

        RaycastHit2D downInfo = Physics2D.Raycast(enemyPos.position, directionDown * rayLength);
        Debug.DrawRay(enemyPos.position, directionDown * rayLength, Color.green);
        

    }



}
