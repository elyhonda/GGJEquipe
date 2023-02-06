using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public GameObject gameObject;
    public AudioSource src;
    public AudioClip clip;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
        int moeda = UnityEngine.Random.Range(0,2);
        if (moeda == 0 ){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
	    if(collision.gameObject.tag == "Player")
        {
            src.PlayOneShot(clip);
            player.distance += 100;
            Invoke("somMoeda",0.3f);
        }
    }

    void somMoeda()
    {
        Destroy(gameObject);
    }
}
