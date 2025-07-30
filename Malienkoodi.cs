using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Malienkoodi : MonoBehaviour
{
    public GameObject mAlien = null;
    private float liikeNopeus = 5f;
    private float rand;
    private bool luo_lippu;
    private bool liiku_lippu;
    private bool mAlien_loppu_x;

    public GameObject paukku_2 = null;// Räjähdys animaatio

    public GameObject explosion_2 = null; // Räjähdys ääniefekti
    
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
        luo_lippu = false;
        liiku_lippu = false;
        mAlien_loppu_x = true;

        //mAlien = GameObject.Find("mAlien"); ***
                
        //paukku_2 = GameObject.Find("Paukku_2");
                
    }

    // Update is called once per frame
    void Update()
    {

        luo_mAlien();
                        
        if (liiku_lippu) 
        {
            liiku();
   
        }
                
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ammus_5(Clone)"))
        {
            Destroy(this.gameObject);
            GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet += 100;

            GameObject.Find("Explosion_2").GetComponent<AudioSource>().Play();
            
            //mAlien.SetActive(false); ***
            
            //GameObject apupaukku_2 = Instantiate(paukku_2, this.GetComponent<Transform>().position, Quaternion.identity);
            //Destroy(apupaukku_2, 1f);


                        
        }
    }
    

    public void liiku()
    {
        
        if (mAlien != null)
        {
            this.GetComponent<Transform>().Translate(liikeNopeus * Time.deltaTime, 0f, 0f);


            if (this.GetComponent<Transform>().position.x >= 13f)
            {
                Destroy(this.gameObject);


                //this.gameObject.SetActive(true);
                //mAlien.gameObject.transform.position = new Vector3(-10f, 4.5f, 0f); ***
                //luo_lippu = false;
                mAlien_loppu_x = true;
                liiku_lippu = false;
                //Destroy(mAlien);
                //mAlien.SetActive(false); ***

            }
        }



    }
    public void luo_mAlien()
    {
        System.Random rand = new();

        if (rand.Next(0, 2000) <= 1)
        {
            luo_lippu = true;

        }

        if (luo_lippu && mAlien_loppu_x)
        {
            mAlien_loppu_x = false;
            luo_lippu = false;
            liiku_lippu = true;
            
            //mAlien.SetActive(true); ***
            //this.transform.position = new Vector3(-10f, 4.5f, 0f);      

            Instantiate(this.mAlien, new Vector3(-13f, 4.5f, 0f), Quaternion.identity);


        }
        
    }

}