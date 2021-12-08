using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 30;

    public PlayerHPBar HPBar = null;

    private float _maxHealth = 0;

    private void Awake()
    {
        _maxHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        
        HPBar.MapHealth(_maxHealth, Health);
        
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
