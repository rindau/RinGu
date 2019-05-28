using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{

    public static bool paused;

    public GameObject PauseUI;
    public bool paspaude;
    // Update is called once per frame
    private void Start()
    {
        paspaude = false;
    }
    void Update()
    {
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void PauseMenu()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Clicked()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            PauseMenu();
        }
    }
}
