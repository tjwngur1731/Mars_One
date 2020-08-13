using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    public float camSpeed;
    float x, z, y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        x -= h * camSpeed;

        if (x >= 9)
        {
            x = 9;
        }
        else if (x <= -9)
        {
            x = -9;
        }
        transform.position = new Vector3(x, y, z);
    }
}
