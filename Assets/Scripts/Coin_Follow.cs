using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Follow : MonoBehaviour
{
    GameObject pl;
    public GameObject Line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        GameObject follow = (GameObject)Instantiate(Line, transform.position, transform.rotation);
    }

}
