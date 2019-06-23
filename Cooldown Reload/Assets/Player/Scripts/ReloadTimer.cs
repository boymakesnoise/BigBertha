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
        if (currentReloadTime > 0) {
            currentReloadTime -= Time.deltaTime;
            reloadMeter.fillAmount = 1 - (currentReloadTime / reloadTime);
        }
        else {
            siktet.SetActive(true);
        }
    }
}
