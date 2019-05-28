using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_Scene : MonoBehaviour
{
    public Animator animator;
    public bool keisti;
    // Start is called before the first frame update
    void Start()
    {
        keisti = false;
    }

    public void Playgame()
    {
        animator.SetTrigger("Scena");
    }
    // Update is called once per frame
    void Update()
    {
        if (keisti == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
