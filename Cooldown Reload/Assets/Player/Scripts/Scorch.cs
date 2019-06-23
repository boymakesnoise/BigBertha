using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorch : MonoBehaviour
{
    public int spawnTime;
    private SpriteRenderer spriten;

    private void Awake() {
        spriten = GetComponent<SpriteRenderer>();
        spriten.enabled = false;
    }

    void Update() {
        if (spawnTime > 0) {
            spawnTime -= 1;
        }

        if (spawnTime <= 0) {
            spriten.enabled = true;
        }
    }
}
