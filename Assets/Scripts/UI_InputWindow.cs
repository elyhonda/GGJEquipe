using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField]private TMP_InputField inputField;

    private int score = 100;
    [SerializeField]private HighscoreTable highscoreTable;


    public void Start()
    {
        scoreText.text = PlayerController.distanceSave + "";
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ClickOk()
    {
        highscoreTable.AddHighscoreEntry(PlayerController.distanceSave, inputField.text);
        Hide();
    }
}
