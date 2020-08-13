using Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchEventObj : PoolingObject
{
    public override string objectName => "ResearchEvent";

    GameObject cam;

    public override void Init()
    {
        cam = GameObject.Find("Main Camera");
        base.Init();
    }

    void Update()
    {
        transform.LookAt(cam.transform);
    }

    public override void Release()
    {
        base.Release();
    }
}
