﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] columnPrefab;                                 //The column game object.
    public int columnPoolSize = 5;                                  //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public float columnMin = -1f;                                   //Minimum x value of the column position.
    public float columnMax = 3.5f;                                  //Maximum x value of the column position.

    private int RandomPrefab;
    private GameObject[] columns;                                   //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-40, -90);     //A holding position for our unused columns offscreen.
    private float spawnXPosition = 7f;

    private float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;
        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {
            //...and create the individual columns.
            RandomPrefab = Random.Range(0, 8);
            columns[i] = (GameObject)Instantiate(columnPrefab[RandomPrefab], objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector3(spawnXPosition, spawnYPosition);

            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}