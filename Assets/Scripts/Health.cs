using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Health : MonoBehaviour
{
    public Text sctext;
    public int CurHealth;
    public int Maxhealth = 100;
    private Transform bar;
    public bool Leisti;
    // Start is called before the first frame update
    void Start()
    {
        CurHealth = Maxhealth;
        bar = transform.Find("Bar");
        Leisti = false;
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
    public void Low()
    {      
            int sk = 0;
            FunctionPeriodic.Create(() =>
            {
                if (Leisti == true)
                {
                    if (sk == 2)
                    {
                        SetColor(Color.white);
                        sk = 1;
                    }
                    else
                    {
                        SetColor(Color.red);
                        sk = 2;
                    }
                }
            }, 0.075f);
    }

    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
    public void SetColor2()
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = new Color(0.6603774f, 0.3457636f, 0.4000624f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        if (CurHealth > Maxhealth)
        {
            CurHealth = Maxhealth;
        }
    }
}
