using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1;
    [HideInInspector] public Vector2 Direction = Vector2.zero;
    
    private Rigidbody2D physics = null;

    private void Awake()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        physics.velocity = Direction * Speed;
    }
}
