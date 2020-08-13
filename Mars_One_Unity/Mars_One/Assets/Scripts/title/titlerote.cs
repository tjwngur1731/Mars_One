using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlerote : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject earth;
    public GameObject mars;
    public float speed;
    public float rote;
    public float rote1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rote += speed * Time.deltaTime;
        rote1 += (speed + 80) * Time.deltaTime;
        earth.transform.rotation = Quaternion.Euler(-181.092f, rote, -124.61f);
        mars.transform.rotation = Quaternion.Euler(0, rote1, 0);
    }
}
