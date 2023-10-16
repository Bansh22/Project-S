using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectil : MonoBehaviour
{
    private ConfigReader reader;
    Rigidbody2D rigid;
    private int per;
    private float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Init(float damage,Vector3 dir, float speed){
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        Destroy(gameObject);
    }



}