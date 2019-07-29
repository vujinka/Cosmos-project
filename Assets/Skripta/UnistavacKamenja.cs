using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnistavacKamenja : MonoBehaviour {
    public GameObject exposion;
    public GameObject playerExplosion;
    public int scoreValue;   
    private KretanjeMetka kretanjeMetka;
    private Kontroler kontroler;
   

    void Start()
    {
        GameObject kontrolerObject = GameObject.FindWithTag("Kontroler");
        if (kontrolerObject != null)
        {
            kontroler = kontrolerObject.GetComponent<Kontroler>();
        }
        if (kontroler == null)
        {
            Debug.Log("Cannot find 'Kontroler' script");
        }

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Usao u triger Enter");
        if (other.tag == "Granica" || other.tag == "Asteroid" || other.tag == "Asteroid2" || other.tag == "Asteroid3")
        {
            return;
            kontroler.Gameover();
        }
        Instantiate(exposion,transform.position, transform.rotation);
        if (other.tag == "Igrac")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            kontroler.Gameover();
        }
       
        kontroler.AddScore(scoreValue);
        if (scoreValue > 100)
        {
            kretanjeMetka.Update();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        
    }
}
