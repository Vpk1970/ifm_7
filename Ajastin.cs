using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajastin : MonoBehaviour
{
    private float aikaa_jäljellä = 0;
    public bool ajastin_toiminnassa = false;

    public void aseta_aika(float aika)
    {
        aikaa_jäljellä = aika;
        ajastin_toiminnassa = true;

    }

    public float tarkista_aika()
    {
        return aikaa_jäljellä;

    }

    public void vähennä_aikaa()
    {
        if (ajastin_toiminnassa)
        {
            if (aikaa_jäljellä > 0)
            {
                aikaa_jäljellä -= Time.deltaTime;
            }
            else
            {
                // pelaajan_alus = true
                //this.alus.SetActive(true);

                //Debug.Log("Time has run out!");
                aikaa_jäljellä = 0;
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
        vähennä_aikaa();

    }
}