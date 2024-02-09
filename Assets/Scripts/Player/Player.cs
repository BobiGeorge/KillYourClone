using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Shooting shooting;

    public UnityEvent playerDeath;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        playerDeath.Invoke();
    }

    public void DisableMovement()
    {
        playerMovement.enabled = false;
    }

    public void EnableMovement()
    {
        playerMovement.enabled = true;
    }

    public void DisableShooting()
    {
        shooting.enabled = false;
    }

    public void EnableShooting()
    {
        shooting.enabled = true;
    }
}
