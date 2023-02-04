using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMovimento : MonoBehaviour
{
    public int tipoObstaculo;
    float x,y;
    float velocidadeObjeto;
    // Start is called before the first frame update
    void Start()
    {
        //velocidade = UnityEngine.Random.Range(1.5f, 5f);
        //Console.WriteLine(velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        x = -0.01f;;
        transform.Translate(new Vector2(x,y));
    }

    private void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
}
