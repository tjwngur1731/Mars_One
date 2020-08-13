using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    public GameObject mars;

    public float zoomSpeed;

    bool isChangeScene = false;
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1")) isChangeScene = true;
        if (isChangeScene)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mars.transform.position, zoomSpeed * Time.deltaTime);

            Invoke("toIngame", 1.1f);
        }

    }

    public void toIngame()
    {
        SceneManager.LoadScene("Ingame");
    }
}
