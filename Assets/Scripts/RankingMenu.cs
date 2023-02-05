using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingMenu : MonoBehaviour
{
    public GameObject rankingPrefab;
    public HighscoreTable highscoreTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyGo()
    {
        //foreach(GameObject go in rankingPrefab.ChildCount)
        //{
        //    Destroy(go);
        //}
    }

    public void InstantPrefab()
    {
        highscoreTable.ShowList();
    }
}
