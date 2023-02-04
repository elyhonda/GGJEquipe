using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryList;
    float templateHeight = 20f;
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("highscoreTable"))
        {
            highscoreEntryList = new List<HighscoreEntry>()
            {
                
            };

            for(int i = 0; i < highscoreEntryList.Count; i++)
            {
                for(int j = i + 1; j<highscoreEntryList.Count; j++)
                {
                    if(highscoreEntryList[j].score > highscoreEntryList[i].score)
                    {
                        HighscoreEntry tmp = highscoreEntryList[i];
                        highscoreEntryList[i] = highscoreEntryList[j];
                        highscoreEntryList[j] = tmp;
                    }
                }
            }
            
            Highscores highscores = new Highscores{highscoreEntryList = highscoreEntryList};
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscoreTable", json);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("highscoreTable"));

            highscoreEntryTransformList = new List<Transform>();
            foreach(HighscoreEntry highscoreEntry in highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }

        }
        else
        {
            //AddHighscoreEntry(11500, "UTI");
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            //UpdateList(highscores);
        }
        
        //AddHighscoreEntry(11500, "UTI");
        
 
        /*
        Highscores highscores = new Highscores{highscoreEntryList = highscoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */
        
    }
    private void UpdateList(Highscores highscores)
    {
        for(int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j<highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
            float templateHeight = 20f;
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            entryTransform.Find("TextoRank").GetComponent<TMP_Text>().text = rank + "";
            
            int score = highscoreEntry.score;
            entryTransform.Find("TextoScore").GetComponent<TMP_Text>().text = score + "";
            
            string name = highscoreEntry.name;
            entryTransform.Find("TextoNick").GetComponent<TMP_Text>().text = name + "";
            transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name};
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        UpdateList(highscores);
    }

    private class Highscores 
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
