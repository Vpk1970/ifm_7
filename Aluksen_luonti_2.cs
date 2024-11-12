using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluksen_luonti_2 : MonoBehaviour
{
    public GameObject pelaajanAlus = null;
    //public Ajastin aika = null;
    
    // Start is called before the first frame update
    void Start()
    {
        //aika = gameObject.AddComponent<Ajastin>();// Ajastin luokka on koodia gameobject issa
        //aika.aseta_aika(3f);// sekunnit       
        Invoke("luo_alus", 1.0f);
    }
            
    public void luo_alus()
    {
        GameObject apualus = Instantiate(this.pelaajanAlus, new Vector3(0f, -4f, 0f), Quaternion.identity);
    }
}
