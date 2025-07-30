using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajastin : MonoBehaviour
{
    private float aikaa_jaljella = 0;
    public bool ajastin_toiminnassa = false;

    public void aseta_aika(float aika)
    {
        aikaa_jaljella = aika;
        ajastin_toiminnassa = true;

    }

    public float tarkista_aika()
    {
        return aikaa_jaljella;

    }

    public void vahenna_aikaa()
    {
        if (ajastin_toiminnassa)
        {
            if (aikaa_jaljella > 0)
            {
                aikaa_jaljella -= Time.deltaTime;
            }
            else
            {
                // pelaajan_alus = true
                //this.alus.SetActive(true);

                //Debug.Log("Time has run out!");
                aikaa_jaljella = 0;
                ajastin_toiminnassa = false;
            }
        }
    }

    /*private void Start()
    {
        // Starts the timer automatically
        //timerIsRunning = true;
    }*/

    void Update()
    {
        vahenna_aikaa();

    }
}