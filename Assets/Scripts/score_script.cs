using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_script : MonoBehaviour {
    public float count;
    public Text sctext;
    public float PointPerSecond;
        // Use this for initialization
	void Start ()
    {
        count = 0;
        PointPerSecond = 1;

    }
	
	// Update is called once per frame
	void Update ()
    {
        DisplayCount();
        count += PointPerSecond * Time.deltaTime;

    }

    public void DisplayCount()
    {
        sctext.text = " " + Mathf.Round(count);
    }
}
