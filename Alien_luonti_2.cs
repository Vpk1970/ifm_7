using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_luonti : MonoBehaviour
{
    public GameObject Alien_5;
    private float offset = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        for (var y = 1; y <= 4; y = y + 1)
        {
            for (var x = 1; x <= 8; x = x + 1)
            {
                GameObject apualien = Instantiate(Alien_5, new Vector3(x - 8 * offset + 2, 5 - y * offset, 0f), Quaternion.identity);
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
/* Pseudoa:
 * 
 * Begin
 *  offset = 1.2
 *      for y = 1 to 4
 *          for x = 1 to 8
 *              Luo alien_5(x - 8 * offset + 2, 3 - y * offset + 2, 0)...5 - y * offset
 *          endfor
 *      endfor
 * Endbegin
 */
