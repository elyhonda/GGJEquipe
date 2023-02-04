using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObstaculoMovimento1 : MonoBehaviour
{
    float x,y;
    float velocidadeObjeto = -0.07f;
    int inimigo;
    // Start is called before the first frame update
    void Start()
    {
        inimigo = UnityEngine.Random.Range(0,3);
        if(inimigo == 0){
            Destroy(this.gameObject);
        }
        Debug.Log(inimigo);
    }    
    
    void Update()
    {
        
        x = velocidadeObjeto;
        transform.Translate(new Vector2(x,y));
    }
}
