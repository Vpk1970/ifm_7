using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malienkoodi : MonoBehaviour
{
    public GameObject mAlien = null;
    private float liikeNopeus = 5f;
    private float rand;
    private bool liiku_lippu;

    public GameObject paukku = null;// Räjähdys animaatio

    public GameObject explosion = null; // Räjähdys ääniefekti


    //public GameObject paukku = null;

    //public GameObject explosion_3 = null;

    // Start is called before the first frame update
    void Start()
    {

        //this.gameObject.SetActive(true);
        liiku_lippu = false;
        explosion = GameObject.Find("Explosion");

        //explosion_3 = GameObject.Find("Explosion");
        Invoke(nameof(luo_mAlien), 1f);
        


    }

    // Update is called once per frame
    void Update()
    {
        liiku();
        /*this.gameObject.SetActive(false);
        if (true) //Random.Range(0, 5) <= 1
        {
            liiku_lippu = true;
            //this.gameObject.SetActive(true);

        }

        if (liiku_lippu)
        {
            //luo_mAlien();
            //Invoke(nameof(luo_mAlien), 5f);

            //this.gameObject.SetActive(true);
            liiku();
            //Invoke(nameof(liiku), Random.Range(10, 15));
        }*/

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ammus_5(Clone)"))
        {
            //Destroy(this.gameObject);
            this.mAlien.SetActive(false);
            //GameObject apupaukku = Instantiate(this.paukku, this.GetComponent<Transform>().position, Quaternion.identity);
            //Destroy(apupaukku.gameObject, 1f);

            //this.gameObject.SetActive(false);
            //Invoke("aktivoi", Random.Range(10, 15));

            explosion.GetComponent<AudioSource>().Play();

            Invoke(nameof(luo_mAlien), 5f);
            //luo_mAlien();



            //explosion_3.GetComponent<AudioSource>().Play();





            //GameObject apupaukku = Instantiate(this.paukku, this.GetComponent<Transform>().position, Quaternion.identity);
            //Destroy(apupaukku.gameObject, 1f);

        }
    }
    /*public void aktivoi()
    {
        this.gameObject.transform.position = new Vector3(-13f, 4.5f, 0f);

        Debug.Log("T�rm�ys");

        this.gameObject.SetActive(true);

    }*/

    public void liiku()
    {

        //Debug.Log("True");
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
    public void luo_mAlien()
    {
        this.gameObject.transform.position = new Vector3(-13f, 4.5f, 0f);
        this.mAlien.SetActive(true);
        //GameObject apu_mAlien = Instantiate(this.mAlien, new Vector3(-13f, 4.5f, 0f), Quaternion.identity);
        //elossa = 0;
    }

}