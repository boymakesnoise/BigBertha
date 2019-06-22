using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    private bool facingRight = true;
    private SpriteRenderer mySpriteRenderer;

    public GameObject playerChar;
    private SpriteRenderer playerCharSR;

    private void Awake() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        playerCharSR = playerChar.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var h = Input.GetAxis("xAim");
        var v = Input.GetAxis("yAim");
        if (Mathf.Abs(h) > 0.05 || Mathf.Abs(v) > 0.05) {
            var angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            var newRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * 5);
        }

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270 && facingRight) {
            mySpriteRenderer.flipY = true;
            playerCharSR.flipX = true;
        }
        if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270) {
            mySpriteRenderer.flipY = false;
            playerCharSR.flipX = false;
        }

        
    }

}
