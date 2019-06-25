﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject plupp;

    void Update() {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers) {

           renderer.sortingOrder = (int)(renderer.transform.position.y * -100);

        }
    }
}
