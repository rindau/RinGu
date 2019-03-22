using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_script : MonoBehaviour {

    GameObject pl;
        // Start is called before the first frame update
        void Start()
        {
          //pl = GameObject.Find("Canvas");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
              Destroy(gameObject);
              GameObject.Find("Score").GetComponent<score_script>().count++;
            }   
        }
}
