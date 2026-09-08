using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Movement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rb;
    private float horizontalInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody2D not found on Mario. Movement will not work.");
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        // Use Rigidbody2D velocity for physics-consistent movement
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    // Called from UI events (PointerDown)
    public void MoveForward()
    {
        horizontalInput = 1f;
    }

    // Called from UI events (PointerDown)
    public void MoveBackward()
    {
        horizontalInput = -1f;
    }

    // Called from UI events (PointerUp / PointerExit)
    public void StopMoving()
    {
        horizontalInput = 0f;
    }

    public void Jump()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
