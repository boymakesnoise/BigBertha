using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimer : MonoBehaviour
{
    public float reloadTime;
    [HideInInspector] public float currentReloadTime;
    public GameObject reloadMeter;
    private Vector3 origPos;
    private float prutt;

    private void Start() {
        origPos = reloadMeter.transform.position;
        prutt = -747f / reloadTime;
    }

    private void Update() {
        if (currentReloadTime > 0) {
            currentReloadTime -= Time.deltaTime;
            reloadMeter.transform.position = origPos + new Vector3(currentReloadTime * prutt, 0, 0);
        }
    }
}
