using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BatataDoce")
        {
            Debug.Log("batey");
            collision.GetComponent<Animator>().Play("in");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BatataDoce")
        {
            Debug.Log("batey");
            collision.gameObject.GetComponent<Animator>().Play("in");
        }
    }
}
