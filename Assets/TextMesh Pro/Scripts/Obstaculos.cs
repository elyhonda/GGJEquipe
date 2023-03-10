using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Obstaculos : MonoBehaviour
{
    public float tempo;
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    private GameObject prefabSelecionado;
    private PlayerController player;
    public float y;
    int blocoAleatorio;
    void Start()
    {
        StartCoroutine("SpawObstaculo");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //velocidade = UnityEngine.Random.Range(1.5f, 5f);
        //Console.WriteLine(velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawObstaculo(){
        blocoAleatorio = UnityEngine.Random.Range(0,3);
        if (blocoAleatorio == 0 ){
            prefabSelecionado = prefab;
        }
        else if (blocoAleatorio == 1){
            prefabSelecionado = prefab1;
        }else if (blocoAleatorio == 2){
            prefabSelecionado = prefab2;
        }else if(blocoAleatorio ==3){
            prefabSelecionado = prefab3;
        }else{
            prefabSelecionado = prefab4;
        }

        
        
        yield return new WaitForSeconds(tempo);
        //Debug.Log(blocoAleatorio);
        GameObject objetoObstaculoTemp = Instantiate(prefabSelecionado);
        objetoObstaculoTemp.transform. position = new Vector2(1f,y);
        StartCoroutine("SpawObstaculo");
    }

    private void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
    
}
