using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_table_script : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    List<HighscoreEntry> table;


    private void Awake()
    {
        //PlayerPrefs.DeleteKey("highscoreTable");
        //PlayerPrefs.Save();
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        string isimta = PlayerPrefs.GetString("highscoreTable",null);

        table = Deserialise(isimta);   
      
        highscoreEntryTransformList = new List<Transform>();
       

        foreach (HighscoreEntry highscoreEntry in table)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform Container, List<Transform> transformList)
    {
        float templateHeight = 60f;
        Transform entryTransform = Instantiate(entryTemplate, Container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankstring;
        switch (rank)
        {
            default:
            rankstring = rank + "TH"; break;
            case 1: rankstring = "1ST"; break;
            case 2: rankstring = "2ND"; break;
            case 3: rankstring = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankstring;
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name.ToString();

        transformList.Add(entryTransform);
    }


    public string serialise(List<HighscoreEntry> table)
    {
        string serial = "";
        string vardai = "";
        string score = "";
        for (int i = 0; i < table.Count; i++)
        {
            vardai = vardai + ";" + table[i].name;
            score = score + ";" + table[i].score;
        }
        serial = vardai + "|" + score;
        return serial;
    }

    public List<HighscoreEntry> Deserialise(string given)
    {
       // Debug.Log("GIVEN: " + given);
        List<HighscoreEntry> table = new List<HighscoreEntry>();
        if (given == "" || given == null)
        {
            return table;
        }

        int sc = 0;
        string name;
        char[] separator = new char[] { ';' };
        char[] separator2 = new char[] { '|' };

        string[] mas = given.Split(separator2, System.StringSplitOptions.RemoveEmptyEntries);
        //Debug.Log(mas.Length);
        if (mas.Length <= 0)
        {
            return table;
        }
        string[] names = mas[0].Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
        string[] scores = mas[1].Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
        if (names.Length <= 0 || scores.Length <= 0)
        {
            return table;
        }
        if (names.Length <= 0 || scores.Length <= 0)
        {
            return table;
        }
        for (int i = 0; i < names.Length; i++)
        {
            name = names[i];
            sc = int.Parse(scores[i]);
            HighscoreEntry entry = new HighscoreEntry() { score = sc, name = name };
            table.Add(entry);
        }
        return table;
    }



    /// <summary>
    /// Tam kad veiktų json utility, dirba su objektais, o ne su list'ais
    /// </summary>
    public class Highscores
    {
        public List<HighscoreEntry> entryList;
    }


    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
