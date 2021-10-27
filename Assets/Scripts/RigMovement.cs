using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigMovement : MonoBehaviour
{
    public float Speed = 1;
    
    private Vector2 direction = Vector2.zero;
    private Rigidbody2D physics = null;

    private void Awake()
    {
        physics = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        physics.velocity = direction * Speed;
    }
}
