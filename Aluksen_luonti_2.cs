using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluksen_luonti_2 : MonoBehaviour
{
    public GameObject pelaajanAlus;
    //public int elossa = 1;
    public Ajastin aika;
    
    // Start is called before the first frame update
    void Start()
    {
        //aika = gameObject.AddComponent<Ajastin>();// Ajastin luokka on koodia gameobject issa
        //aika.aseta_aika(3f);// sekunnit       
        Invoke("luo_alus", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        /*if(elossa == 1 && aika.ajastin_toiminnassa == false)
        {

        }*/
    }
    public void luo_alus()
    {
        GameObject apualus = Instantiate(this.pelaajanAlus, new Vector3(0f, -4f, 0f), Quaternion.identity);
        //elossa = 0;
    }
}
