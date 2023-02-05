using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int moeda = UnityEngine.Random.Range(0,2);
        if (moeda == 0 ){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
	    if(collision.gameObject.tag == "Jogador")
        {
            Destroy(gameObject);
        }
    }
}