using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    #region Virables

    public float Speed = 1;
    [HideInInspector] public Vector2 Direction = Vector2.zero;

    public float Damage = 1;

    public float LifeTime = 5;
    
    private Rigidbody2D physics = null;

    #endregion

    private void Awake()
    {
        physics = GetComponent<Rigidbody2D>();

        StartCoroutine(_iDestroyBullet());
    }

    private void FixedUpdate()
    {
        physics.velocity = Direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(Damage);
        }
        else if (other.collider.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            player.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }

    private IEnumerator _iDestroyBullet()
    {
        // Hier passiert stuff sofort
        yield return new WaitForSeconds(LifeTime);
        // Hier passiert stuff nach Lifetime Sekunden
        
        Destroy(gameObject);
    }
}
