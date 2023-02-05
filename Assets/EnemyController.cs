using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour    
{
    PlayerController player;


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
        

    }

    public void Move()
    {
        Vector2 pos = transform.position;
        pos.x += 0.25f;
        transform.position = pos;
    }


    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            
        }
    }*/

}
