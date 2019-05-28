using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_script : MonoBehaviour
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
            GameObject.Find("Score").GetComponent<score_script>().count = GameObject.Find("Score").GetComponent<score_script>().count + 10;            
        }
    }
}
