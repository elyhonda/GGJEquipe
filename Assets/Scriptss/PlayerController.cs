using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
 
    public float jumpForce;
    public Vector2 velocity;
    public float distance;
    public float maxXVelocity = 100f;
    public float maxAcceleration = 10f;
    public float acceleration = 10f;
 
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
 
    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;
 
 
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        Jump();
    }
 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        distance += velocity.x * Time.fixedDeltaTime;
        
        if(isGrounded)
        {

            float velocityRatio = velocity.x / maxXVelocity;
            velocity.x += acceleration * Time.deltaTime;
            acceleration = maxAcceleration * (1 - velocityRatio);
            if(velocity.x >= maxXVelocity)
            {
            velocity.x = maxXVelocity;
            }
        }
    }
 
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            rb.velocity = Vector2.up * jumpForce;
        }
 
        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
 
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
}