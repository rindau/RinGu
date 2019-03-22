using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_script : MonoBehaviour {
    public int count;
    public Text sctext;  
        // Use this for initialization
	void Start ()
    {
        count = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DisplayCount();
	}

    public void DisplayCount()
    {
        sctext.text = "SCORE: " + count.ToString();
    }
}
