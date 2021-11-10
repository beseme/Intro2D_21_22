using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 30;

    public void TakeDamage(float damage)
    {
        Health -= damage;
       
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
