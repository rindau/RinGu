using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public Animator animator;
    public bool keisti;
    public bool keisti2;
    public void Start()
    {
        keisti = false;
        keisti2 = false;
    }
    public void Playgame()
    {
        animator.SetTrigger("Scena");
        PlayerPrefs.SetInt("CurSc", 0);
        PlayerPrefs.Save();
    }
    public void HighScore()
    {
        animator.SetTrigger("Scena2");
    }
   
    public void Update()
    {
        if (keisti == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (keisti2 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
    }
    public void keitimas()
    {
        keisti = true;
    } 
    public void keitimas2()
    {
        keisti2 = true;
    }
}
