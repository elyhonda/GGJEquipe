using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    PlayerController player;
    TMP_Text distanceText;


    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        distanceText = GameObject.Find("DistanceText").GetComponent<TMP_Text>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";*/
    }
}
