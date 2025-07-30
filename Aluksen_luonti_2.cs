using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aluksen_luonti_2 : MonoBehaviour
{
    public GameObject pelaajanAlus;
    public Ajastin aika;
    
    // Start is called before the first frame update
    void Start()
    { 
        Invoke("luo_alus", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void luo_alus()
    {
        GameObject apualus = Instantiate(this.pelaajanAlus, new Vector3(0f, -4f, 0f), Quaternion.identity);
    }   
}
