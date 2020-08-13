﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                }
            }
        }
        
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    void TakeResearchEvent()
    {

    }
}
