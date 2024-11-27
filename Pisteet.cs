using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pisteet : MonoBehaviour
{
    public int pisteet = 0;
    private GameObject score_teksti = null;

    // Start is called before the first frame update
    void Start()
    {
        this.score_teksti = GameObject.Find("score_text");

    }

    // Update is called once per frame
    void Update()
    {
        score_teksti.GetComponent<Text>().text = "SCORE " + pisteet.ToString("0");

    }
}
