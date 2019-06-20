using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xVelAdj;
    public float yVelAdj;
    public float speed;

    private void Update() {
        xVelAdj = Input.GetAxisRaw("xMove");
        yVelAdj = Input.GetAxisRaw("yMove");
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(xVelAdj * speed, yVelAdj * speed, 0);
    }
}
