using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private int scorePlayer;
    
    [SerializeField] private InputField inputNick;
    [SerializeField] private GameObject rankingPrefab;
    [SerializeField] private GameObject gridPosicao;
    [SerializeField] private GameObject posicaoPrefab;
    [SerializeField] private GameObject inputPrefab;
    
    void Awake()
    {
        gridPosicao = GameObject.Find("GridPosicao");
        inputNick = inputPrefab.GetComponent<InputField>();
        scorePlayer = 1000; //Editar score

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void InputNickName()
    {
        name = inputNick.text;
        UpdateScore();
    }
    void UpdateScore()
    {
        rankingPrefab.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(posicaoPrefab, gridPosicao.transform);

            int rank = i + 1;
            gridPosicao.transform.GetChild(i).transform.Find("TextoRank").GetComponent<TMP_Text>().text = rank + "";
            int score = 100;
            gridPosicao.transform.GetChild(i).transform.Find("TextoScore").GetComponent<TMP_Text>().text = score + "";
            string name = "AAA";
            gridPosicao.transform.GetChild(i).transform.Find("TextoNick").GetComponent<TMP_Text>().text = name + "";
        }

    }

    private void CreateHighScore(HighScoreEntry highscoreEntry)
    {
        
    }
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
