using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed;
    Vector3 moveTrans;

    void Start()
    {
        moveTrans = transform.position;
        StartCoroutine(RandomMove(Random.Range(1f, 3f)));
    }

    void FixedUpdate()
    {
        Vector3 dir = moveTrans - transform.position;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(dir), moveSpeed);
        transform.localRotation = new Quaternion(0f, transform.localRotation.y, 0f, 1f); // 수고했어 ㅎㅎ 한번 만 더 보자
    }

    IEnumerator RandomMove(float duration = 2f)
    {
        float progress = 0f;
        while (progress <= duration)
        {
            progress += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, moveTrans, Time.deltaTime);
            yield return null; 
        }
        moveTrans = new Vector3(Random.Range(-3f, 3f), transform.position.y, Random.Range(-3f, 3f));
        //transform.LookAt(moveTrans);
        StartCoroutine(RandomMove(Random.Range(1f, 2f)));
    }
}
