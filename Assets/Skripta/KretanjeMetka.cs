using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeMetka : MonoBehaviour
{
    private Rigidbody rb;
    private Kontroler kontroler;
    public float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }
    public void Update()
    {
       
            speed -= 50f;
        
    }


}
