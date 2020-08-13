using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pooling;

public class ResearchEventPooling : MonoBehaviour
{
    public GameObject researchEvent;

    ObjectPool<ResearchEventObj> ResearchEvent = new ObjectPool<ResearchEventObj>();

    bool isre;

    float curTime;
    float maxTime;

    Money money;

    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        isre = false;
        ResearchEvent.Init(researchEvent, 1, Vector3.zero, null, transform, false);
        money = GetComponent<Money>();
        money.SetRe(isre);
        maxTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime>=maxTime)
        {
            ResearchSpawn();
            curTime = 0;
        }
    }

    void ResearchSpawn()
    {
        isre = money.GetRe();
        if (!isre)
        {
            ResearchEvent.Spawn(target.position + new Vector3(0, 4, 0));
            money.SetRe(true);
        }
        
    }

    
}
