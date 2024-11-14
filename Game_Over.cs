using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// T‰m‰ liitet‰‰n Game_Over skeneen kameraan

public class Game_Over : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float _score = PlayerPrefs.GetFloat("score");
        GameObject.Find("score_text").GetComponent<Text>().text = "SCORE " + _score.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);

        }
    }
}
