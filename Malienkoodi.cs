using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malienkoodi : MonoBehaviour
{
    private float liikeNopeus = 5f;
    private float rand;
    private bool liiku_lippu;

    //public GameObject paukku = null;

    //public GameObject explosion_3 = null;

    // Start is called before the first frame update
    void Start()
    {
        
        //this.gameObject.SetActive(true);
        liiku_lippu = false;

        //explosion_3 = GameObject.Find("Explosion");

    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.SetActive(false);
        if (Random.Range(0, 10000) <= 1)
        {
            liiku_lippu = true;
            //this.gameObject.SetActive(true);

        }

        if (liiku_lippu)
        {
            //this.gameObject.SetActive(true);
            liiku();
            //Invoke(nameof(liiku), Random.Range(10, 15));
        }
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ammus_5(Clone)"))
        {
            //explosion_3.GetComponent<AudioSource>().Play();

            this.gameObject.SetActive(false);
            Invoke("aktivoi", Random.Range(10, 15));

            

            //GameObject apupaukku = Instantiate(this.paukku, this.GetComponent<Transform>().position, Quaternion.identity);
            //Destroy(apupaukku.gameObject, 1f);

        }
    }
    public void aktivoi()
    {
        this.gameObject.transform.position = new Vector3(-13f, 4.5f, 0f);

        Debug.Log("Törmäys");

        this.gameObject.SetActive(true);

    }

    public void liiku()
    {
        
            Debug.Log("True");
            this.GetComponent<Transform>().Translate(liikeNopeus * Time.deltaTime, 0f, 0f); ;

        //for (int i = 0; i < 360; i++)
        //{
        //    this.transform.Rotate(0, 0, i, Space.Self);
        //}
        if (this.GetComponent<Transform>().position.x >= 13f)
        {
            //this.gameObject.SetActive(true);
            this.gameObject.transform.position = new Vector3(-13f, 4.5f, 0f);
            liiku_lippu = false;

        }
    }

}