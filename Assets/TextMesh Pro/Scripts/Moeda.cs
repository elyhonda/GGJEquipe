using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public GameObject gameObject;
    public AudioSource src;
    public AudioClip clip;
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
	    if(collision.gameObject.tag == "Player")
        {
            src.PlayOneShot(clip);
            Invoke("gameOver",1f);
            
        }
    }
    void gameOver(){
        Destroy(gameObject);
    }
}
