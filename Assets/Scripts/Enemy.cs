using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 10;
    
    public GameObject BulletObject = null;
    public float Cooldown = .5f;

    public EnemyHPBar HPBar = null;
    
    public AudioClip ShootSFX = null;

    private float maxHealth = 0;
    
    private bool shotFired = false;
    private float cooldownRef = 0;
    
    private AudioSource source = null;
    
    private void Awake()
    {
        source = GetComponent<AudioSource>();

        maxHealth = Health;
    }
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
        
        HPBar.MapHealth(maxHealth, Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        /*if (!shotFired)
        {
            StartCoroutine(iShoot());
        }*/

        cooldownRef -= Time.deltaTime;

        if (cooldownRef <= 0)
        {
            shoot();
            cooldownRef = Cooldown;
        }
    }

    private IEnumerator iShoot()
    {
        shotFired = true;
        yield return new WaitForSeconds(Cooldown);
        
        shoot();
        shotFired = false;
    }

    private void shoot()
    {
        source.PlayOneShot(ShootSFX);
        // Winkel zwischen Spieler und Gegner
        Vector2 aimAt = GameManager.Instance.Player.transform.position - transform.position;

        GameObject currentBullet = Instantiate(BulletObject, transform.position, Quaternion.identity);

        Bullet bullet = currentBullet.GetComponent<Bullet>();
        
        bullet.Direction = aimAt.normalized;
    }
}
