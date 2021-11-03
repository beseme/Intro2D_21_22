using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 10;

    public void TakeDamage(float damage)
    {
        Debug.Log(Health);

        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
