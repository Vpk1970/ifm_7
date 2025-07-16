#define UNITY_ASSERTIONS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.VisualScripting;

using System.Xml.Schema;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class Alien_liike_2 : MonoBehaviour
{
    private float alku_x; // Alienin alkupiste x
    private float loppu_x; // Alienin loppupiste x

    private int suunta; // Alienin liikkumissuunta -1 tai 1
    private float x_matka; // Alienin kulkema matka
    private float nopeus; // Liikkumisnopeus
    private bool suunnanVaihto; // Vaihdetaanko alienien liikkumissuuntaa ?
    private bool alienienLuonti;
    private float aikaclamp;
    private Vector3 origAlienPos; // Alienien alkupiste
    private Vector3 origAlienPosMax; // Alienien loppupiste

    
    private float alien_up_to_down_offset; // Alienien liikkuminen pystysuunnassa

    private float y_alienAlareuna; // Alin piste

    private AlienLuontiTehdas_2 alienlt;

    static int alienDeaths = 0;

    private float xMin; // Alaraja jonka yl�puolella suunnanVaihto on true
    private float xMax; // Yl�raja jonka alapuolella suunnanVaihto on true

    private Transform _transform;

    static float addAlienSpeed = 0.75f;

    public GameObject paukku = null;

    public GameObject explosion = null;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        suunta = 1;
        x_matka = 8.0f;
        nopeus = 2.5f;
        suunnanVaihto = false;
        alien_up_to_down_offset = 0.1f;
        y_alienAlareuna = -2f;

        origAlienPos = this.GetComponent<Transform>().position;
        origAlienPosMax = new Vector3(this.GetComponent<Transform>().position.x + x_matka, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z);
        
        xMin = 0.2f * x_matka;
        xMax = 0.2f * x_matka;

        alku_x = this.GetComponent<Transform>().position.x;
        loppu_x = this.GetComponent<Transform>().position.x + x_matka; // oli 7

        AlienLuontiTehdas_2 alienlt = GetComponent<AlienLuontiTehdas_2>();

        _transform = this.GetComponent<Transform>();

        explosion = GameObject.Find("Explosion");

    }

    // Update is called once per frame
    void Update()
    {

        AlienLiike();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ammus_5(Clone)"))
        {
            Destroy(this.gameObject);

            explosion.GetComponent<AudioSource>().Play();

            GameObject apupaukku = Instantiate(this.paukku, this.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(apupaukku.gameObject, 1f);

            alienDeaths += 1;
            if (alienDeaths == 32)
            {
                addAlienSpeed += 0.1f;
                if (addAlienSpeed >= 2)
                {
                    addAlienSpeed = 2;
                }
                Debug.Log(addAlienSpeed);

                alienDeaths = 0;
                AlienLuontiTehdas_2 alienlt = GameObject.Find("Koodia").GetComponent<AlienLuontiTehdas_2>();
                alienlt.Invoke(nameof(AlienLuontiTehdas_2.AlienLuonti_2), 3.0f);

            }
            GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet += 10;
        }
    }

    public void AlienLiike()
    {
        // vähennä y jos reunoissa
        this._transform.position = Dec_Y_position(); 

        // Tarkistetaan onko alien lohkojen A ja C ulkopuolella.
        suunnanVaihto = IsOutsideOfBlocks_A_and_C(alku_x, xMin, loppu_x, xMax); 

        // Onko alien reunoissa jolloin k��nnet��n suunta.
        IsAlienOnEdges(loppu_x, alku_x);


        // Change alien position
        this._transform.position += nopeus * addAlienSpeed * Time.deltaTime * new Vector3(1f * suunta, 0f, 0f);// localPosition ???        

    }

    public bool IsOutsideOfBlocks_A_and_C(float alku_x, float xMin, float loppu_x, float xMax)
    {
        // T�ss� tarkistetaan onko alien lohkojen A ja C ulkopuolella jolloin suunnanVaihto on true.

        if ((this._transform.position.x >= alku_x + xMin) || (this._transform.position.x <= loppu_x - xMax))
        {
            return true;

        }
        else
        {
            return false;

        }

    }

    public Vector3 Dec_Y_position()
    {
        if (this._transform.position.x <= alku_x)
        {
            return origAlienPos - new Vector3(0f, alien_up_to_down_offset += 0.1f, 0f);

        }
        if (this._transform.position.x >= loppu_x)
        {
            return origAlienPosMax - new Vector3(0f, alien_up_to_down_offset += 0.1f, 0f);
        }
        else
        {
            return this._transform.position;

        }

    }

    public void IsAlienOnEdges(float loppu_x, float alku_x)
    {
        if (((this._transform.position.x >= loppu_x) && (suunnanVaihto)) || ((this._transform.position.x <= alku_x) && (suunnanVaihto))) // ???
        {
            suunta *= -1;
            suunnanVaihto = false;

            if (this.GetComponent<Transform>().position.y <= y_alienAlareuna)
            {
                Destroy(this.gameObject);
                PlayerPrefs.SetFloat("score", GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet);
                SceneManager.LoadScene(2);

            }

        }
     }
}


