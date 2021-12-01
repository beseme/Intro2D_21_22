using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletObject = null;
    
    public float Cooldown = .5f;

    public AudioClip clip = null;
    
    private float cooldownRef = 0;

    private AudioSource source = null;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        cooldownRef -= Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldownRef <= 0)
            {
                shoot();
                cooldownRef = Cooldown;
            }
        }
    }

    private void shoot()
    {
        source.PlayOneShot(clip, 1);
        
        /*Screen to world Point wandelt screen space (UI) ind world space (spiel) um.
         Mausposition ist teil der Input klasse.
         transform.position kann immer abgefragt werden, da wir von monobehaviour erben
         wir zielen also in die Richtung, die zwischen unserer Position und der Mausposition aufgespannt wird*/
        Vector2 aimAt = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        /*Wir schreiben das neue Objekt auf eine lokale variable, damit wir wie hier z.B. den Bullet Component bekommen*/
        GameObject currentBullet = Instantiate(BulletObject, transform.position, Quaternion.identity);

        Bullet bullet = currentBullet.GetComponent<Bullet>();

        // Der Vektor muss noch normalisiert werden, damit er immer den gleichen Betrag hat
        bullet.Direction = aimAt.normalized;
    }
}
