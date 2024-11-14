using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_ammus_liike : MonoBehaviour
{
    [SerializeField]
    private float nopeus = -10f;
    private float alaraja = -4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().Translate(0f, nopeus * Time.deltaTime, 0f);



        if (this.GetComponent<Transform>().position.y < alaraja)
        {
            Destroy(this.gameObject);

        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("ship(Clone)"))
        {
            Debug.Log("alien osui alukseen");


        }
    }*/
}