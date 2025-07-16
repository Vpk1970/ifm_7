using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLuontiTehdas_2 : MonoBehaviour
{
    public GameObject alien;
    private float offset = 1.2f; // alienien väli joka suunnassa

    //public GameObject bitsound_2 = null;

    //private float aikaajaljella = 10;

    // Start is called before the first frame update
    void Start()
    {
        //bitsound_2 = GameObject.Find("bittisoundi_2");
        //bitsound_2.GetComponent<AudioSource>().Play();

        /*for (float y = 1f; y <= 4f; y = y + 1f)
        {
            for (float x = 1f; x <= 8f; x = x + 1f)
            {
                GameObject apualien = Instantiate(Alien_5, new Vector3(x - 8 * offset + 2, 5 - y * offset, 0f), Quaternion.identity);
            }   
        }*/

        Invoke(nameof(AlienLuonti_2), 3.0f);
        //AlienLuonti_2();

        

}

    // Update is called once per frame
    void Update()
    {
    }
    public GameObject AlienLuonti_2()
    {
        /*for (int i = 0;i < 1000000000; i++)
        {

        }*/
        //Debug.Log("ajastin loppu");

        //if (aikaajaljella < 0)
        //{
            for (float y = 0f; y <= 3f; y = y + 1f)
            {
                for (float x = 0f; x <= 7f; x = x + 1f)
                {
                GameObject gameObject1 = Instantiate(alien, new Vector3(-8 + (offset * x), 4 - (offset * y), 0f), Quaternion.identity);
                gameObject1.name = "Alien";

                }
            }
            //aikaajaljella = 10;

        //}
        // aikaajaljella -= Time.deltaTime;


        return gameObject;

        //Alien_5.name = "alien";

    }
}
/* Pseudoa:
 * 
 * Begin
 *  offset = 1.5
 *      for y = 1 to 4
 *          for x = 1 to 8
 *              Luo alien_5(-8 + (offset * x), 4 - (offset * y), 0)
 *          endfor
 *      endfor
 * Endbegin
 */

