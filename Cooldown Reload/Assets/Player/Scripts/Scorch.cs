using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorch : MonoBehaviour {
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

    // Paja väggar & döda fiender
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "enemy") {
            Destroy(other.gameObject);
        }
    }
}