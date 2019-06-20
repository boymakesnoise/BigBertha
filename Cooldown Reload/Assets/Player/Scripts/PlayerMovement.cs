using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xVelAdj;
    public float yVelAdj;
    public float xFire;
    public float yFire;

    public float speed;
    //private Rigidbody2D spelaren;
    //private Camera mainCamera;

    private void Start() {
        //spelaren = GetComponent<Rigidbody2D>();
        //mainCamera = FindObjectOfType<Camera>();
    }

    private void Update() {
        //Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        //Plane groundPlane = new Plane(Vector3.back, Vector3.zero);
        //float rayLength;

        //if (groundPlane.Raycast(cameraRay, out rayLength)) {
        //    Vector3 pointToLook = cameraRay.GetPoint(rayLength);
        //    Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

        //    transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, transform.position.z));
        //}

        xVelAdj = Input.GetAxis("xMove");
        yVelAdj = Input.GetAxis("yMove");

        
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector3(xVelAdj * speed, yVelAdj * speed, 0);
        //if (Input.GetKey(KeyCode.D)) {
        //    //transform.Translate(Vector2.right * speed);
        //    //transform.position += Vector3.right * speed;
        //    spelaren.AddForce(Vector2.right * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A)) {
        //    spelaren.AddForce(Vector2.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W)) {
        //    spelaren.AddForce(Vector2.up * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S)) {
        //    spelaren.AddForce(Vector2.down * speed * Time.deltaTime);
        //}
    }
}
