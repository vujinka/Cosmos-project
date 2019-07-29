using System.Collections;
using System.Collections.Generic;


using UnityEngine;


    [System.Serializable]
public class Granice
{
    public float xMin, xMax, zMin, zMax;
}

public class PomeranjeIgraca : MonoBehaviour
{
    
    private Rigidbody rb;
    public float tilt;
    public Granice granice;
    public float speed;

    public GameObject Shot;
    public Transform ShotSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;


    void Update()
    {
       // EditorApplication.Beep();
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //EditorApplication.Beep();
            nextFire = Time.time + fireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            audioSource.Play();
        }
    }



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

        

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        

        

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, granice.xMin, granice.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, granice.zMin, granice.zMax)
        );

       rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}


