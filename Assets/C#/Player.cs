using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    [SerializeField] private GameObject sprite;
    [SerializeField] private bool faceRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
        Flip();

        if (faceRight == false && moveInput.x > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Walk()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveVelocity = moveInput.normalized * speed;
    }
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = sprite.transform.localScale;
        Scaler.x *= -1f;
        sprite.transform.localScale = Scaler;
    }
}
