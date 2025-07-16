using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// T‰m‰ liitet‰‰n Game_Over skeneen kameraan

public class Game_Over : MonoBehaviour
{

    public GameObject bitsound_3 = null;

    // Start is called before the first frame update
    void Start()
    {
        bitsound_3 = GameObject.Find("bittisoundi_3");
        bitsound_3.GetComponent<AudioSource>().Play();

        //Screen.SetResolution(1024, 768, false);
        float _score = PlayerPrefs.GetFloat("score");
        GameObject.Find("score_text").GetComponent<Text>().text = "SCORE " + _score.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(0);

        }
    }
}

