using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public float acceleration = 10;
    public float distance = 0;
    public float maxAcceleration = 10;
    public float maxXVelocity = 100;
    public float groundHeight = 10;
    public float jumpVelocity = 20;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;
    public float jumpGroundThreshold = 3;
    
    public Vector2 velocity;

    public bool isGrounded;
    public bool isHoldingJump = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        if(isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
            }

            
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                isHoldingJump = false;
            }   
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if(!isGrounded)
        {
            if(isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;
            if(!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            
            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if(hit2D.collider != null)
            {
                Ground ground = hit2D.collider.GetComponent<Ground>();
                if(ground != null)
                {
                    pos.y = groundHeight;
                    isGrounded = true;
                }
               
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.blue);
        }
        
        distance += velocity.x * Time.fixedDeltaTime;

        if(isGrounded)
        {
            
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);

            velocity.x += acceleration * Time.fixedDeltaTime;
            if(velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }


            Vector2 rayOrigin = new Vector2(pos.x - 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.deltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if(hit2D.collider == null)
            {
                isGrounded = false;
               
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.green);
        }
        

        transform.position = pos;


    }
}
