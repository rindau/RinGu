using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade_script : MonoBehaviour
{
    public Animator animator;
    private int leveltoLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel( int levelIndex)
    {
        leveltoLoad = levelIndex;
        animator.SetTrigger("Scena");
    }
    public void onfadeComplete()
    {
        SceneManager.LoadScene(leveltoLoad);
    }
}
