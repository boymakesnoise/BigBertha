﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

}
