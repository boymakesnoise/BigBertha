using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        var h = Input.GetAxis("xAim");
        var v = Input.GetAxis("yAim");
        if (Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05) {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            var newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 5);
        }



        //Vector3 shootDirection = new Vector3(Input.GetAxis("xAim"), Input.GetAxis("yAim"), 0f);

        ////Vector3 swordDirection = Vector3.right * Input.GetAxis("xAim") + Vector3.down * Input.GetAxis("yAim");

        //if (shootDirection.sqrMagnitude > 0.0f) {

        //    //transform.rotation = Quaternion.LookRotation(shootDirection, Vector2.up);



        //    var newRot = Quaternion.LookRotation(shootDirection, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 5);

        //}

    }
}
