using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddMoneyText : MonoBehaviour
{

    public float moveSpeed;
    public float alphaSpeed;
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int addMoney;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = addMoney.ToString();
        alpha = text.color;
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a,0,Time.deltaTime * alphaSpeed);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
