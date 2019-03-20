using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Out_Of_Bounds : MonoBehaviour
{
    private Scene Scena;
    // Start is called before the first frame update
    void Start()
    {
        Scena = SceneManager.GetActiveScene();
    }   
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(Scena.name);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else { }
    }
}
