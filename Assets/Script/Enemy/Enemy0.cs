using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    new CapsuleCollider2D collider;
    EnemyFuntion funtion;
    Dictionary data;

    float speed;
    int hp;
    int damage;
    bool isLive = true;
    Vector3 moveVec;
    Vector3 currentVelocity; // 현재 속도
    Vector3 targetVelocity; // 목표 속도

    // Start is called before the first frame update
    void Start()
    {
        data = new Dictionary("Enemy0");
        speed = data.Init<float>("speed");
        hp= data.Init<int>("hp");
        damage= data.Init<int>("damage");

        funtion = new EnemyFuntion(gameObject);
        funtion.setTracePlayer(GameManager.instance.player);
        funtion.setSpeed(speed);

        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            //anim.SetTrigger("Dead");
            collider.enabled = false;
            isLive = false;
        }
        if (!isLive)
            return;

        funtion.trace();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //anim.SetTrigger("Hit");
        }
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}