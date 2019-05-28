using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meteordie : MonoBehaviour
{
    private Scene Scena;
    public GameObject particles;
    public GameObject touchparticles;
    private GameObject zaidejas;
    public GameObject scoreobj;
    private int health;
    string gautasvardas;
    int scr;
    // Start is called before the first frame update
    void Start()
    {
        Scena = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")         
        {
            zaidejas = collision.gameObject;
            GameObject.Find("Health").GetComponent<Health>().CurHealth = GameObject.Find("Health").GetComponent<Health>().CurHealth - 25;
            float life = GameObject.Find("Health").GetComponent<Health>().CurHealth;
            GameObject.Find("Health").GetComponent<Health>().SetSize(life/100);
            health = GameObject.Find("Health").GetComponent<Health>().CurHealth;
            if (health == 25)
            {
                GameObject.Find("Health").GetComponent<Health>().Leisti = true;
                GameObject.Find("Health").GetComponent<Health>().Low();
            }          
            if (health == 0)
            {
                scr = (int)GameObject.Find("Score").GetComponent<score_script>().count;
                gautasvardas = PlayerPrefs.GetString("vardas");
                PlayerPrefs.SetInt("CurSc", scr);
                PlayerPrefs.Save();
                scoreobj.GetComponent<Add_score>().AddHighEntry(scr, gautasvardas);

                Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(zaidejas);
                StartCoroutine(wait());             
            }           
            else
            {
                Instantiate(touchparticles, transform.position, Quaternion.identity);
            }
        }
        else { }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
#pragma warning disable CS0618 // Type or member is obsolete
        SceneManager.LoadScene(1);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}

