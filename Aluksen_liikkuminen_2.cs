using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Aluksenliikkuminen : MonoBehaviour
{
    private float liikkumis_nopeus = 10f;
    private float x_oikea_reuna = 8;
    private float x_vasen_reuna = -8;

    public int elamat = 3;
    public GameObject pelaajanAlus = null;
    private GameObject lives_teksti = null;

    public GameObject paukku_2 = null;

    
    // Start is called before the first frame update
    void Start()
    {
        this.lives_teksti = GameObject.Find("lives_teksti");
        this.lives_teksti.GetComponent<Text>().text = "ELÄMÄT: " + elamat;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.GetComponent<Transform>().position.x < x_oikea_reuna)
            {
                //this.GetComponent<Rigidbody>().position = Vector3.zero;
                this.GetComponent<Transform>().Translate(liikkumis_nopeus * Time.deltaTime, 0f, 0f);//Time.deltaTime; sama nopeus eri koneilla

            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.GetComponent<Transform>().position.x > x_vasen_reuna)
            {
                //this.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0f, liikkumis_nopeus * Time.deltaTime, 0f));
                this.GetComponent<Transform>().Translate(-liikkumis_nopeus * Time.deltaTime, 0f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


        lives_teksti.GetComponent<Text>().text = "ELÄMÄT: " + elamat.ToString("0");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name.Equals("Ammus_4(Clone)"))
        {
            this.pelaajanAlus.SetActive(false);//Destroy(this.gameObject);
            this.elamat -= 1;
            //Debug.Log(elamat);
            this.lives_teksti.GetComponent<Text>().text = "ELÄMÄT: " + elamat;

            GameObject apupaukku_2 = Instantiate(this.paukku_2, this.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(apupaukku_2.gameObject, 1f);

            // Tähän väliin ajastimella tauko
            Invoke("luo_alus", 2.0f);

            

            if (this.elamat <= 0)
            {
                
                Destroy(this.gameObject);

                PlayerPrefs.SetFloat("score", GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet);

                //Debug.Log(GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet);

                SceneManager.LoadScene(2);


                
            }
        }
    }
    public void luo_alus()
    {
        this.GetComponent<Transform>().position = new Vector3(0f, -4f, 0f);
        this.pelaajanAlus.SetActive(true);
    }
}
