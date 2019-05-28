using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Script : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameObject.Find("Health").GetComponent<Health>().CurHealth = GameObject.Find("Health").GetComponent<Health>().CurHealth + 25;
            float life = GameObject.Find("Health").GetComponent<Health>().CurHealth;
            if (life < 101)
            {
                GameObject.Find("Health").GetComponent<Health>().SetSize(life / 100);
            }
            if (life == 50)
            {
                GameObject.Find("Health").GetComponent<Health>().Leisti = false;
                GameObject.Find("Health").GetComponent<Health>().SetColor2();
            }
        }
    }
}
