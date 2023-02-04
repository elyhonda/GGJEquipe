using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    private Button okBtn;
    private Button cancelBtn;
    private TextMeshProUGUI titleText;
    [SerializeField]private TMP_InputField inputField;

    private int score = 100;
    [SerializeField]private HighscoreTable highscoreTable;

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
        highscoreTable.AddHighscoreEntry(score, inputField.text);
        Hide();
    }
}
