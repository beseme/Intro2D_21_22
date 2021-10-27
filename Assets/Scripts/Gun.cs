using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletObject = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject currentBullet = Instantiate(BulletObject, transform.position, Quaternion.identity);

        Bullet bullet = currentBullet.GetComponent<Bullet>();

        Vector2 aimAt = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        bullet.Direction = aimAt.normalized;
    }
}
