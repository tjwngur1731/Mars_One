using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float dist;
    public float camSpeed;

    float x, z, y;

    void Start()
    {
        x = 0;
        y = 7.11f;
        z = 9.23f;
    }

    void Update()
    {
        float t = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        x -= h * camSpeed;
        z -= t * camSpeed;

        if (z <= -11.48999f)
        {
            z = -11.48999f;
        }
        else if (z >= 27.22998f)
        {
            z = 27.22998f;
        }
        if(x >= 18.47999f)
        {
            x = 18.47999f;
        }
        else if(x <= -27.91997f)
        {
            x = -27.91997f;
        }
        transform.position = new Vector3(x, y, z);
    }
}