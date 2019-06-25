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
    private GameManager GM;
    private GameObject gun;
    private AimGun aimGun;

    private void Start() {
        GM = FindObjectOfType<GameManager>();
        gun = GameObject.FindWithTag("gun");
        aimGun = gun.GetComponent<AimGun>();
    }

    private void Update() {
        
        bullet = GameObject.FindGameObjectWithTag("skott");

        CheckInput();

        print(aimGun.facingRight);
    }

    private void FixedUpdate() {
        if (bullet != null || GM.gameHasEnded) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            return;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(xVelAdj * speed, yVelAdj * speed, 0);
    }

    private void CheckInput() {
        if (bullet != null || GM.gameHasEnded) {
            animator.SetFloat("Speed", 0);
            return;
        }

        xVelAdj = Input.GetAxisRaw("xMove");
        yVelAdj = Input.GetAxisRaw("yMove");

        animator.SetFloat("Speed", Mathf.Abs(xVelAdj) + Mathf.Abs(yVelAdj));

        if (xVelAdj < 0 && aimGun.facingRight) {
            animator.SetBool("WalkingBackwards", true);
            //animator.SetFloat("Speed", 0);
        }
        if (xVelAdj > 0 && !aimGun.facingRight) {
            animator.SetBool("WalkingBackwards", true);
            //animator.SetFloat("Speed", 0);
        }

        if (xVelAdj < 0 && !aimGun.facingRight) {
            animator.SetBool("WalkingBackwards", false);
        }
        if (xVelAdj > 0 && aimGun.facingRight) {
            animator.SetBool("WalkingBackwards", false);
        }
    }

}
