using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add_score: MonoBehaviour
{
    List<HighscoreEntry> table;
    public void AddHighEntry(int score, string name)
    {

        HighscoreEntry ent = new HighscoreEntry() { score = score, name = name };
        string st = PlayerPrefs.GetString("highscoreTable", null);
        
        table = Deserialise(st);
        table.Add(ent);
        table.Sort((emp1, emp2) => emp1.score.CompareTo(emp2.score));
        table.Reverse();
        if (table.Count > 5)
        {
            table.RemoveRange(5, table.Count - 5);
        }

        string sv = serialise(table);
        PlayerPrefs.SetString("highscoreTable",sv);
        PlayerPrefs.Save();
    }


    //private class Highscores
    //{
    //    public List<HighscoreEntry> entryList;
    //}


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


    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
