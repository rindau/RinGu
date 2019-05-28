using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Space: MonoBehaviour
{
    public float parallaxfactor = 0f;
    public int MaxStars = 100;
    public float StarSize = 0.1f;
    public float StarSizeRange = 0.8f;
    public float FieldWidth = 6000f;
    public float FieldHeight = 2050f;
    public bool Colorize = false;

    ParticleSystem Particles;
    ParticleSystem.Particle[] Stars;
    private Camera cam;

    void Awake()
    {
        Stars = new ParticleSystem.Particle[MaxStars];
        Particles = GetComponent<ParticleSystem>();
        cam = Camera.main;

        Assert.IsNotNull(Particles, "Particle system missing from object!");

        float xOffset = FieldWidth * 0.5f;                                                                                                        // Offset the coordinates to distribute the spread
        float yOffset = FieldHeight * 0.5f;                                                                                                       // around the object's center

       
        for (int i = 0; i < MaxStars; i++)
        {
            float randSize2 = Random.Range(0.01f, 0.1f);
            float randSize = Random.Range(0f,1f);                       // Randomize star size within parameters
            float scaledColor = (true == Colorize) ? randSize : 1f;         // If coloration is desired, color based on size
            float scaledColor2 = (true == Colorize) ? randSize2 : 1f;

            Stars[i].position = GetRandomInRectangle(FieldWidth, FieldHeight, xOffset, yOffset);
            Stars[i].startSize = StarSize * randSize;
            Stars[i].startColor = new Color(scaledColor, scaledColor, 1f, 1f);
        }
        Particles.SetParticles(Stars, Stars.Length);                                                                // Write data to the particle system
    }

    void Update()
    {
        //Vector3 newPos = cam.gameObject.transform.position * parallaxfactor;                   // Calculate the position of the object
        //newPos.z = 0;                       // Force Z-axis to zero, since we're in 2D
        //transform.position = newPos;
        float xOffset = FieldWidth * 0.5f;                                                                                                        // Offset the coordinates to distribute the spread
        float yOffset = FieldHeight * 0.5f;

        for (int i = 0; i < MaxStars; i++)
        {
            Vector3 pos = Stars[i].position + transform.position;

            if (pos.x < (cam.gameObject.transform.position.x - xOffset))
            {
                pos.x += FieldWidth;
            }
            else if (pos.x > (cam.gameObject.transform.position.x + xOffset))
            {
                pos.x -= FieldWidth;
            }

            if (pos.y < (cam.gameObject.transform.position.y - yOffset))
            {
                pos.y += FieldHeight;
            }
            else if (pos.y > (cam.gameObject.transform.position.y + yOffset))
            {
                pos.y -= FieldHeight;
            }

            Stars[i].position = pos - transform.position;
        }
        Particles.SetParticles(Stars, Stars.Length);

    }



    // GetRandomInRectangle
    //----------------------------------------------------------
    // Get a random value within a certain rectangle area
    //
    Vector3 GetRandomInRectangle(float width, float height, float xoffset, float yOffset)
    {
        float x = Random.Range(0, width);
        float y = Random.Range(0, height);
        return new Vector3(x - xoffset, y - yOffset, 0);
    }
}
