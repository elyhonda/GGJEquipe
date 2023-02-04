using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Obstaculos : MonoBehaviour
{
    public float tempo;
    public GameObject prefab;
    void Start()
    {
        StartCoroutine("SpawObstaculo");
        
        //velocidade = UnityEngine.Random.Range(1.5f, 5f);
        //Console.WriteLine(velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawObstaculo(){
        yield return new WaitForSeconds(tempo);
        GameObject objetoObstaculoTemp = Instantiate(prefab);
        StartCoroutine("SpawObstaculo");
    }

}
