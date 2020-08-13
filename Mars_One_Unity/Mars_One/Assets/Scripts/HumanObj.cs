using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pooling;

public class HumanObj : PoolingObject
{
    public override string objectName => "Human";

    public override void Init()
    {
        base.Init();
    }

    void Update()
    {

    }

    public override void Release()
    {
        base.Release();
    }

}
