using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    Vector2 mousePosition;
    public Transform firePoint;

    private int fireMode;

    public GameObject bulletPrefab;
    public float bulletForce;

    public Camera camera;

    private void Start()
    {
        fireMode = 1;
    }

    void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        SelectWeapon();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - playerRigidbody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        playerRigidbody.rotation = angle;
    }

    void Shoot()
    {
        switch (fireMode) {
            case 1:
                ShootBullet();
                break;
            case 2:
                ShootShotgun();
                break;
            case 3:
                ShootCrossbow();
                break;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }

    private void ShootShotgun()
    {
        Quaternion[] instantiateRotation = new Quaternion[]{
            firePoint.rotation * new Quaternion(0, 0, 0.4f, 1),
            firePoint.rotation * new Quaternion(0, 0, 0.2f, 1),
            firePoint.rotation * new Quaternion(0, 0, 0, 1),
            firePoint.rotation * new Quaternion(0, 0, -0.2f, 1),
            firePoint.rotation * new Quaternion(0, 0, -0.4f, 1)
        };

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position , instantiateRotation[0]);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, instantiateRotation[1]);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, instantiateRotation[2]);
        GameObject bullet4 = Instantiate(bulletPrefab, firePoint.position, instantiateRotation[3]);
        GameObject bullet5 = Instantiate(bulletPrefab, firePoint.position, instantiateRotation[4]);

        Rigidbody2D bulletRigidbody1 = bullet1.GetComponent<Rigidbody2D>();
        bulletRigidbody1.AddForce(bullet1.transform.right * bulletForce, ForceMode2D.Impulse);

        Rigidbody2D bulletRigidbody2 = bullet2.GetComponent<Rigidbody2D>();
        bulletRigidbody2.AddForce(bullet2.transform.right * bulletForce, ForceMode2D.Impulse);

        Rigidbody2D bulletRigidbody3 = bullet3.GetComponent<Rigidbody2D>();
        bulletRigidbody3.AddForce(bullet3.transform.right * bulletForce, ForceMode2D.Impulse);
            
        Rigidbody2D bulletRigidbody4 = bullet4.GetComponent<Rigidbody2D>();
        bulletRigidbody4.AddForce(bullet4.transform.right * bulletForce, ForceMode2D.Impulse);

        Rigidbody2D bulletRigidbody5 = bullet5.GetComponent<Rigidbody2D>();
        bulletRigidbody5.AddForce(bullet5.transform.right * bulletForce, ForceMode2D.Impulse);
    }

    private void ShootCrossbow()
    {
        throw new NotImplementedException();
    }


    void SelectWeapon()
    {
        if (Input.GetKeyDown("1"))
            fireMode = 1;
        else if (Input.GetKeyDown("2"))
            fireMode = 2;
        else if (Input.GetKeyDown("3"))
            fireMode = 3;
    }
}
