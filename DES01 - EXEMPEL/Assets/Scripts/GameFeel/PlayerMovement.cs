using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed, jumpSpeed;
    [SerializeField] ContactFilter2D groundFlter;

    private bool isGrounded;
    private bool isJumping;
    private Vector2 moveInput;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded)
        { isJumping = true; }    
    }

    void OnFire()
    {

    }

    void Update()
    {
        Run();
    }

    void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFlter);

        if (isJumping)
        {
            rb.velocity += (new Vector2(0f, jumpSpeed));
            isJumping = false;
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        if (moveInput.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveInput.x);
            transform.localScale = scale;
        }
    }

}
