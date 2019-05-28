using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectedScene : MonoBehaviour
{
    public void load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


}
