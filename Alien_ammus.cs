using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Alien_ammus : MonoBehaviour
{
    public GameObject alien_ammus = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0f, 100f) <= 0.01)
        {
            GameObject apualienammus = Instantiate(this.alien_ammus, new Vector3(this.GetComponent<Transform>().position.x,
                this.GetComponent<Transform>().position.y - 0.9f, 0f), Quaternion.identity);
            
            //Debug.Log(apualienammus.name);
        }
    
    }
    
}

