using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public float theScrollSpeed = 0.000025f;
    private float koordinate;
    Transform theCamera;
    scrolling objektas;
    void Start()
    {
        theCamera = Camera.main.transform;
    }

    void Update()
    {
        theCamera.position = new Vector3(theCamera.position.x, theCamera.position.y - theScrollSpeed, theCamera.position.z);      
    }
}

