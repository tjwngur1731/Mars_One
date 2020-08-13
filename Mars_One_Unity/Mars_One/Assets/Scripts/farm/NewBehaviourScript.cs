using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject liveobj;
    private bool islive;

    float h;
    float v;

    public float randomTerm;
    float curRandom;

    Transform tr;

    public float moveSpeed;

    [SerializeField] private Transform tf_Destination;

    NavMeshAgent agent;

    Rigidbody rigid;

    private Vector3 originPos;

    private bool isgo;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        originPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(liveobj.activeSelf == false)    
        {
            curRandom += Time.deltaTime;
            if (curRandom >= randomTerm)
            {
                h = Random.Range(-1, 2) * moveSpeed;
                v = Random.Range(-1, 2) * moveSpeed;
                curRandom = 0;
            }
            //rigid.AddForce(new Vector3(h, 0, v),ForceMode.Impulse);
            tr.position += new Vector3(h, 0, v) * Time.deltaTime;
        }
        else if (liveobj.activeSelf == true)
        {
            if (Vector3.Distance(transform.position, tf_Destination.position) < 1.1f)
            {
                isgo = true;
            }
            else if (Vector3.Distance(transform.position, originPos) < 1.1f)
            {
                isgo = false;
            }
            if (isgo == true)
            {
                agent.SetDestination(originPos);

            }
            else if (isgo == false)
            {
                agent.SetDestination(tf_Destination.position);
            }
        }

    }
}
