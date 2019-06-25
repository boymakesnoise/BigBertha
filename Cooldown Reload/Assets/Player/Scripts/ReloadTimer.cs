using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadTimer : MonoBehaviour
{
    public float reloadTime;
    [HideInInspector] public float currentReloadTime;
    public Image reloadMeter;
    public GameObject siktet;

    private void Update() {
        if (currentReloadTime > 0 && Input.GetAxisRaw("Reload1") > 0.5) {
            currentReloadTime -= Time.deltaTime;
        }
        if (currentReloadTime <= 0) {
            siktet.SetActive(true);
        }

        reloadMeter.fillAmount = 1 - (currentReloadTime / reloadTime);
    }
}
