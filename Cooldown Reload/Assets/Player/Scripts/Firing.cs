using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private ReloadTimer reloadTime;

    private void Start() {
        reloadTime = GetComponent<ReloadTimer>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        if (reloadTime.currentReloadTime <= 0f) {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            reloadTime.currentReloadTime = reloadTime.reloadTime;
        }
    }
}
