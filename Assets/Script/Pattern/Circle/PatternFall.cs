using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternFall : MonoBehaviour
{
    Transform trans;
    Rigidbody2D rigid;
    SpriteRenderer render;
    public GameObject parent;
    // Start is called before the first frame update
    void Awake()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.position.y < parent.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
