using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pooling;

public class ObjectPooling : MonoBehaviour
{
    public GameObject humanObj;
    public GameObject humanObj2;

    ObjectPool<HumanObj> human = new ObjectPool<HumanObj>();
    ObjectPool<HumanObj> human2 = new ObjectPool<HumanObj>();


    float x;
    float y;
    float z;
    float x2;
    float y2;
    float z2;

    float curHumanSpawn;
    public float maxHumanSpawn;

    void Start()
    {
        human.Init(humanObj, 10, null, null, transform, false);
        human2.Init(humanObj2, 10, null, null, transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        curHumanSpawn += Time.deltaTime;

        if(curHumanSpawn>maxHumanSpawn)
        {
            //x = Random.Range(-50, 50);
            //y = 0.5f;
            //z = Random.Range(-50, 50);
            //x2 = Random.Range(-50, 50);
            //y2 = 0.5f;
            //z2 = Random.Range(-50, 50);

            //human.Spawn(new Vector3(x / 10, y, z / 10),Quaternion.Euler(0,0,0));
            //human2.Spawn(new Vector3(x2 / 10, y2, z2 / 10),Quaternion.Euler(0,0,0));

            //curHumanSpawn = 0;

            
        }
    }

    public void HumanSpawn()
    {

    }
}
