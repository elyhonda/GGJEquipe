using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public MeshRenderer mr;
    public float depth;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        float realVelocity = player.velocity.x / depth;


        mr.material.mainTextureOffset += new Vector2(realVelocity* Time.deltaTime, 0);
    }
}
