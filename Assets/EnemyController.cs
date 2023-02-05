using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector2 velocity;
    public float maxXVelocity = 80f;
    public float maxAcceleration = 6f;
    public float acceleration = 5f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float velocityRatio = velocity.x / maxXVelocity;
        velocity.x += acceleration * Time.deltaTime;
        acceleration = maxAcceleration * (1 - velocityRatio);
        
        if(velocity.x >= maxXVelocity)
        {
        velocity.x = maxXVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
