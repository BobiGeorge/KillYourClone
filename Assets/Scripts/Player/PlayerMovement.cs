using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D playerRigidbody;

    Vector2 movement;

    private void Start()
    {
        moveSpeed = 5f;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
