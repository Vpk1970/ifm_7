using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public GameObject bitsound = null;

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(800, 600, false);

        bitsound = GameObject.Find("bittisoundi");
        bitsound.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
