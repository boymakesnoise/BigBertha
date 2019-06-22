using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public int maxHP = 100;
    public float currentHP = 100;
    public Image HPMeter;
    private bool takingDamage = false;

    void Update()
    {
        if (takingDamage && currentHP > 0) {
            currentHP -= 1;
        }

        HPMeter.fillAmount = currentHP / maxHP;

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