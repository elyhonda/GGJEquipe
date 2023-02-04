using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMovimento : MonoBehaviour
{
    float x,y;
    float velocidadeObjeto;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        x = -0.15f;
        transform.Translate(new Vector2(x,y));
    }

    private void OnBecameInvisible(){
        Destroy(this);
    }
}
