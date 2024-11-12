using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLuontiTehdas_2 : MonoBehaviour
{
    public GameObject alien = null;
    public float offset = 1.5f; // alienien väli joka suunnassa
        
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(AlienLuonti_2), 3.0f);
     
    }
            
    public GameObject AlienLuonti_2()
    {
        
        for (float y = 0f; y <= 3f; y = y + 1f)
        {
            for (float x = 0f; x <= 7f; x = x + 1f)
            {
                GameObject gameObject1 = Instantiate(alien, new Vector3(-8 + (offset * x), 4 - (offset * y), 0f), Quaternion.identity);
                gameObject1.name = "Alien";
            }

        }

        return gameObject;
         
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

