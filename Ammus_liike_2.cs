using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammus_liike_2 : MonoBehaviour
{
    [SerializeField]
    private float nopeus = 35f;
    private float ylaraja = 6f;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody>().AddForce(Vector2.up * nopeus);
    }

    // Update is called once per frame
    void Update()
    {
        // Ammus liikkuu koneen nopeudesta riippumatta samalla nopeudella

        this.GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(0f, nopeus * Time.deltaTime, 0f));

        //this.Ammus_6.GetComponent<Rigidbody2D>().AddForce(Vector2.up * nopeus);
        
        if (this.GetComponent<Transform>().position.y > ylaraja)
        {
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Alien"))
        {
            Destroy(this.gameObject);

            GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet += 10;
            //GameObject.Find("Koodia").GetComponent<score_lives>().pisteet += 10;
            

        }
        if (collision.name.Equals("Malien"))
        {
            //Debug.Log("T�rm�ys");
            GameObject.Find("Koodia").GetComponent<Pisteet>().pisteet += 350;

        }
    }
    
}
