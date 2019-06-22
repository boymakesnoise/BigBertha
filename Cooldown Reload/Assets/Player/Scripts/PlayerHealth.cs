using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public int maxHP = 100;
    public int currentHP = 100;
    public GameObject HPMeter;
    private Vector3 origPos;
    private float prutt;
    private bool takingDamage = false;

    void Start()
    {
        origPos = HPMeter.transform.position;
        prutt = -368f / currentHP;
    }

    void Update()
    {
        if (takingDamage && currentHP > 0) {
            currentHP -= 1;
        }

        HPMeter.transform.position = origPos + new Vector3((maxHP - currentHP) * prutt, 0, 0);
    }

    void OnTriggerStay(Collider scorchedEarth) {
        currentHP -= 1;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bullet") {
            takingDamage = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "bullet") {
            takingDamage = false;
        }
    }
}