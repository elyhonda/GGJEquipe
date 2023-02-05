using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour    
{
    PlayerController player;
    public float counterVelocity;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.x -= player.velocity.x * Time.fixedDeltaTime / counterVelocity;

        if (pos.x < -100)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
