using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// T‰m‰ tiedosto liitet‰‰n alukseen

public class Ammus_2 : MonoBehaviour
{
    public GameObject pelaajanAmmus = null;
    public GameObject pelaajanAlus = null;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject apuammus = Instantiate(this.pelaajanAmmus, new Vector3(this.pelaajanAlus.GetComponent<Transform>().position.x,
                this.pelaajanAlus.GetComponent<Transform>().position.y + 0.9f, 0f), Quaternion.identity);
            
        }
    }
}
