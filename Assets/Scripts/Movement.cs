using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed =100f ;
    int life = 100;
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;
    public float bus = 0;
    
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        life = GameObject.Find("Health").GetComponent<Health>().CurHealth;
        GameObject.Find("Player").GetComponent<Animator>().SetInteger("HEALTH", life);
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                RunCharacter(1.0f,moveSpeed);
                bus = 2f;
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f,moveSpeed);
                bus = 0f;
            }
            ++i;
        }
    }
    void FixedUpdate()
    {
        RunCharacter(Input.GetAxis("Horizontal"),moveSpeed);
    }

    private void RunCharacter(float horizontalInput, float movespeed)
    {
        //move player
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
      
    }
}
