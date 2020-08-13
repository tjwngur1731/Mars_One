using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject mars;
    bool isChangeScene = false;
    public float zoomSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            isChangeScene = true;
        }
        if (isChangeScene == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mars.transform.position, zoomSpeed * Time.deltaTime);

            Invoke("toIngame", 2.0f);
        }
    }

    public void toIngame()
    {
        SceneManager.LoadScene("Ingame");
    }
}
