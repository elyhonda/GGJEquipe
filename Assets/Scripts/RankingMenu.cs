using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingMenu : MonoBehaviour
{
    public GameObject gridPosicao;
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
        for (int i = 0; i < gridPosicao.transform.childCount; i++)
        {
            Destroy(gridPosicao.transform.GetChild(0).gameObject);
        }
    }

    public void InstantPrefab()
    {
        highscoreTable.ShowList();
    }
}
