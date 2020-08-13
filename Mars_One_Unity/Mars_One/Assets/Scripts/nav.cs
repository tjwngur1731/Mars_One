using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    Rigidbody myRigid;
    [SerializeField] private float moveSpeed;

    NavMeshAgent agent;

    [SerializeField] private Transform tf_Destination;
    private Vector3 originPos;
    private bool isgo;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, tf_Destination.position) < 0.3f)
        {
            isgo = true;
        }
        else if (Vector3.Distance(transform.position, originPos) < 0.2f)
        {
            isgo = false;
        }
        if (isgo == true)
        {
            agent.SetDestination(originPos);
            transform.LookAt(originPos);

        }
        else if(isgo == false)
        {
            agent.SetDestination(tf_Destination.position);
            transform.LookAt(tf_Destination.position);
        }
    }
}