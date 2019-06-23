using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skott : MonoBehaviour
{
    public int despawnTime;

    void Update()
    {
        if (despawnTime > 0) {
            despawnTime -= 1;
        }

        if (despawnTime <= 0) {
            Destroy(gameObject);
        }
    }
}
