#define UNITY_ASSERTIONS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
using Unity.VisualScripting;
//using System;
using System.Xml.Schema;
using UnityEngine.UIElements;
//using System;
//using Debug = System.Diagnostics.Debug;
//


public class Alien_liike_2 : MonoBehaviour
{
    private float alku_x; // Alienin alkupiste
    private float loppu_x; // Alienin loppupiste

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

    //public GameObject alien;

    //public GameObject alienAmmus;
    //private GameObject apuluonti;

    public AlienLuontiTehdas_2 alienlt = null;

    static int alienDeaths = 0;

    private float xMin; // Alaraja jonka yläpuolella suunnanVaihto on true
    private float xMax; // Yläraja jonka alapuolella suunnanVaihto on true

    public Transform _transform = null;

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

    }

    // Update is called once per frame
    void Update()
    {

        //[Conditional(UNITY_ASSERTIONS)]
        //Debug.Assert(alku_x == loppu_x);

        // Jos alku_x on sama kuin loppu_x tulee ilmoitus konsoliin
        //UnityEngine.Debug.Assert(suunnanVaihto == true);
        
        this._transform.position += nopeus * Time.deltaTime * new Vector3(1f * suunta, 0f, 0f);// localPosition ???        

        if (this._transform.position.x <= alku_x)
        {
            this._transform.position = origAlienPos - new Vector3( 0f, alien_up_to_down_offset += 0.1f, 0f);

            //Debug.Log(this.transform.position.x);

        }
        if (this._transform.position.x >= loppu_x)
        {
            this._transform.position = origAlienPosMax - new Vector3( 0f, alien_up_to_down_offset += 0.1f, 0f);

            //suunnanVaihto = true;

        }
  

        if ((this._transform.position.x >= alku_x + xMin) || (this._transform.position.x <= loppu_x - xMax))
        {
            suunnanVaihto = true;
            //Debug.Log(suunnanVaihto);
            //alienienLuonti = true;


        }
        else
        {
            suunnanVaihto = false;
            //Debug.Log(suunnanVaihto);
        }

        

        vaihdetaankoSuunta();

        // Tee tämä metodiksi...Tehty!

        /*if (((this._transform.position.x >= loppu_x) && (suunnanVaihto)) || ((this._transform.position.x <= alku_x) && (suunnanVaihto))) // ???
        {
            suunta *= -1;
            suunnanVaihto = false;          
            
            Debug.Log(this._transform.position.x);
                        
            if (this.GetComponent<Transform>().position.y <= y_alienAlareuna)
            {
                //Application.Quit();
                Destroy(this.gameObject);

            }

        }*/

        // Metodin loppu

        /*if ((this.transform.position.x <= alku_x) && (alienienLuonti == true))
        {
            //suunta *= -1.0f;
            alienienLuonti = false;

            AlienLuontiTehdas_2 alienlt = GameObject.Find("Koodia").GetComponent<AlienLuontiTehdas_2>();

            alienlt.Invoke(nameof(AlienLuontiTehdas_2.AlienLuonti_2), 0.0f);

            alku_x = this.GetComponent<Transform>().position.x;
            loppu_x = this.GetComponent<Transform>().position.x + x_matka;

        }*/

        /*if ((this.transform.position.x <= alku_x) && (alienienLuonti == true))
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Alien_tag"))
            {
                Destroy(o);
            }

            //Destroy(GameObject.Find("Alien"));

            AlienLuontiTehdas_2 alienlt = GameObject.Find("Koodia").GetComponent<AlienLuontiTehdas_2>();

            alienlt.Invoke(nameof(AlienLuontiTehdas_2.AlienLuonti_2), 0.0f);

            alienienLuonti = false;

            alku_x = this.GetComponent<Transform>().position.x;
            loppu_x = this.GetComponent<Transform>().position.x + x_matka;

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Equals("Ammus_5(Clone)"))
            {
                Destroy(this.gameObject);
                alienDeaths += 1;
                if (alienDeaths == 32)
                {
                    alienDeaths = 0;
                    AlienLuontiTehdas_2 alienlt = GameObject.Find("Koodia").GetComponent<AlienLuontiTehdas_2>();
                    alienlt.Invoke(nameof(AlienLuontiTehdas_2.AlienLuonti_2), 3.0f);

                }
                GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet += 10;
            }
        }

    public void vaihdetaankoSuunta()
        {
            if (((this._transform.position.x >= loppu_x) && (suunnanVaihto)) || ((this._transform.position.x <= alku_x) && (suunnanVaihto))) // ???
                {
                    suunta *= -1;
                    suunnanVaihto = false;

                    Debug.Log(this._transform.position.x);

            if (this.GetComponent<Transform>().position.y <= y_alienAlareuna)
                {
                    //Application.Quit();
                    Destroy(this.gameObject);

                }

        }
    }
}

