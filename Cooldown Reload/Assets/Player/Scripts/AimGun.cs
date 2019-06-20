using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    private bool facingRight = true;
    private float angles;

    void Update()
    {
        var h = Input.GetAxis("xAim");
        var v = Input.GetAxis("yAim");
        if (Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05) {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            var newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 5);
        }

        //angles = transform.eulerAngles.z;
        //Flip(angles);

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270 && facingRight) {
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.y *= -1;
            transform.localScale = theScale;
        }
        if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270) {
            if (!facingRight) {
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.y *= -1;
                transform.localScale = theScale;
            }
        }
        print(facingRight);
    }

    //private void Flip(float angles) {
    //    if (angles > 90 && angles < 270 && facingRight) {
    //        facingRight = !facingRight;
    //    }
    //}
}
