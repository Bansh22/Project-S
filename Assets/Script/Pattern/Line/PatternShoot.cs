using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternShoot : MonoBehaviour
{
    Transform trans;
    Rigidbody2D rigid;
    SpriteRenderer render;

    // Start is called before the first frame update
    void Awake()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }
    public void Init(Vector3 dir)
    {
        rigid.velocity = dir*5f;
    }
}
