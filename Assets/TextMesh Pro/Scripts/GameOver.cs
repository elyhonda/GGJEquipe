using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
	    if(collision.gameObject.tag == "Player")
        {
            src.PlayOneShot(clip);
            Invoke("gameOver",1f);
            
        }
    }
    void gameOver(){
        SceneManager.LoadScene("GameOver");
    }
}

