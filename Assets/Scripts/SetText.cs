using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetText : MonoBehaviour
{
   
    public InputField nm;
    string vard;
    string previousVard;
    int cursc;
    GameObject txtname;
    void Start()
    {
        vard = PlayerPrefs.GetString("vardas");
        txtname = GameObject.FindGameObjectWithTag("nmTxt");
        cursc = PlayerPrefs.GetInt("CurSc");
        if (cursc > 0)
        {
            txtname.GetComponent<Text>().text = vard + " SCORED: " + cursc.ToString();
        }
        else
        {
            txtname.GetComponent<Text>().text = "";
        }

        if (vard.Length > 0)
            nm.text = vard;
    }

    public void setGet()
    {
        
        vard = nm.text;

        if (vard.Length == 0)
            vard = "ANONYMOUS";

        PlayerPrefs.SetString("vardas", vard);
        PlayerPrefs.SetInt("CurSc", 0);
        PlayerPrefs.Save();    
    }

    public void load(int n)
    {
        SceneManager.LoadScene(n);
    }
}
