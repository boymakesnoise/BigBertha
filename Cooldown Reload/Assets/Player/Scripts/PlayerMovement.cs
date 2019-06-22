using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xVelAdj;
    public float yVelAdj;
    public float speed;
    public Animator animator;

    private void Update() {
        xVelAdj = Input.GetAxisRaw("xMove");
        yVelAdj = Input.GetAxisRaw("yMove");

        animator.SetFloat("Speed", Mathf.Abs(xVelAdj) + Mathf.Abs(yVelAdj));
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(xVelAdj * speed, yVelAdj * speed, 0);
    }
}
