using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicZombie : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D zombieRigidbody;
    Vector3 movement = new Vector3(0,0);

    public UnityEvent death;

    void Start()
    {
        moveSpeed = 0.07f;
        zombieRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        zombieRigidbody.position = Vector2.MoveTowards(zombieRigidbody.position, GameObject.FindWithTag("Player").transform.position, moveSpeed);
    }

    void Die()
    {
        death.Invoke();
        Destroy(this.gameObject);
    }

    //for example using some sort of item to briefly attract enemies 
    void SwitchTarget()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Die();
        }
    }
}
