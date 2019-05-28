using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public Animator animator;
    public bool keisti;
    public bool keisti2;
    // Start is called before the first frame update
    void Start()
    {
        keisti = false;
        keisti2 = false;
    }
    public void Back()
    {
        animator.SetTrigger("Scena");
    }
    public void Play()
    {
        animator.SetTrigger("Scena2");
    }

    // Update is called once per frame
    void Update()
    {
        if (keisti == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (keisti2 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
