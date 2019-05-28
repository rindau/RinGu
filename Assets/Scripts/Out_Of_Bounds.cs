using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Out_Of_Bounds : MonoBehaviour
{
    public GameObject scoreobj;  
    string gautasvardas;
    int scr;
    private GameObject zaidejas;
    public GameObject particles;
    // Start is called before the first frame update
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            zaidejas = collision.gameObject;
            scr = (int)GameObject.Find("Score").GetComponent<score_script>().count;
            gautasvardas = PlayerPrefs.GetString("vardas");
            PlayerPrefs.SetInt("CurSc", scr);
            PlayerPrefs.Save();
            //GameObject.Find("TextManager").GetComponent<SetText>().nm.text = gautasvardas;
            scoreobj.GetComponent<Add_score>().AddHighEntry(scr, gautasvardas);
            Instantiate(particles, zaidejas.transform.position, Quaternion.identity);
            Destroy(zaidejas);
            StartCoroutine(wait());
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
