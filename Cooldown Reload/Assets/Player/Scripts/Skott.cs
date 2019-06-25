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

        //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2000);
        //int i = 0;
        //while (i < hitColliders.Length) {
        //    hitColliders[i].SendMessage("Shot");
        //    i++;
        //}
    }
}
