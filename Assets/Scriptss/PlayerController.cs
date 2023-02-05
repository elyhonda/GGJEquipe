using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    
    EnemyController cenoura;

    public float jumpForce;
    public Vector2 velocity;
    public float distance;
    public static int distanceSave;
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
 
    public AudioSource src;
    public AudioClip clip;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cenoura = GameObject.Find("cenoura").GetComponent<EnemyController>();
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Jump();
    }
 
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        distance += velocity.x * Time.fixedDeltaTime;
        Debug.Log(distance);
        distanceSave = (int)distance;
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
            src.PlayOneShot(clip);
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


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Obstacle")
        {
            Destroy(col.gameObject);
            velocity.x *= 0.8f;
            cenoura.Move();  
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
}