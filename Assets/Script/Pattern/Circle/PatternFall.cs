using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternFall : MonoBehaviour
{
    Transform trans;
    Rigidbody2D rigid;
    SpriteRenderer render;
    public GameObject parent;
    public float speed=3;
    float accel = 0.06f;
    float force = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (speed < 10f)
        {
            speed += force;
            force += accel;
        }
       trans.Translate((parent.transform.position-trans.position).normalized*speed * Time.fixedDeltaTime);
    }
}
