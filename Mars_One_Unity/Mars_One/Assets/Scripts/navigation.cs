using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigation : MonoBehaviour
{
    Rigidbody myRigid;
    [SerializeField] private float moveSpeed;

    NavMeshAgent agent;

    [SerializeField] private Transform tf_Destination;
    private Vector3 originPos;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, tf_Destination.position) < 0.1f)
        {
            agent.SetDestination(originPos);
        }
        else if (Vector3.Distance(transform.position, originPos) < 0.1f)
        {
            agent.SetDestination(tf_Destination.position);
        }
    }
}
