using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajastin : MonoBehaviour
{
    private float aikaa_j�ljell� = 0;
    public bool ajastin_toiminnassa = false;

    public void aseta_aika(float aika)
    {
        aikaa_j�ljell� = aika;
        ajastin_toiminnassa = true;

    }

    public float tarkista_aika()
    {
        return aikaa_j�ljell�;

    }

    public void v�henn�_aikaa()
    {
        if (ajastin_toiminnassa)
        {
            if (aikaa_j�ljell� > 0)
            {
                aikaa_j�ljell� -= Time.deltaTime;
            }
            else
            {
                // pelaajan_alus = true
                //this.alus.SetActive(true);

                //Debug.Log("Time has run out!");
                aikaa_j�ljell� = 0;
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
        v�henn�_aikaa();

    }
}