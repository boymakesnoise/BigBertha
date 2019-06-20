using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    void Update()
    {
        var h = Input.GetAxis("xAim");
        var v = Input.GetAxis("yAim");
        if (Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05) {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            var newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 5);
        }
    }
}
