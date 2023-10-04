using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    new CapsuleCollider2D collider;
    EnemyFuntion funtion;

    float speed = 2.5f;
    float hp = 100;
    float damage = 10;
    bool isLive = true;
    Vector3 moveVec;
    Vector3 currentVelocity; // 현재 속도
    Vector3 targetVelocity; // 목표 속도

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        funtion = new EnemyFuntion(gameObject);
        funtion.setTracePlayer(GameManager.instance.player);
        funtion.setSpeed(speed);
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
        SapWappon sappon = new SapWappon();
        if (!collision.gameObject.CompareTag("Bullet"))
            return;

        hp -= sappon.Getdamage();

        if (hp > 0)
        {

        }
        else
        {
            //Dead();
        }

    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}