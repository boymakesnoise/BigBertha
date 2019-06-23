using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xVelAdj;
    public float yVelAdj;
    public float speed;
    public Animator animator;
    public GameObject skottet;
    private GameObject bullet;

    private void Update() {
        
        bullet = GameObject.FindGameObjectWithTag("skott");

        CheckInput();
    }

    private void FixedUpdate() {
        if (bullet != null) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            return;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(xVelAdj * speed, yVelAdj * speed, 0);
    }

    private void CheckInput() {
        if (bullet != null) {
            animator.SetFloat("Speed", 0);
            return;
        }

        xVelAdj = Input.GetAxisRaw("xMove");
        yVelAdj = Input.GetAxisRaw("yMove");

        animator.SetFloat("Speed", Mathf.Abs(xVelAdj) + Mathf.Abs(yVelAdj));
    }

}
