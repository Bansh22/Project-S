using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    Player tracePlayer;
    Animator anim;
    Transform trans;
    Rigidbody2D rigid;

    float speed = 2.5f;
    int hp = 100;
    int damage = 10;
    Vector3 moveVec;
    Vector3 currentVelocity; // 현재 속도
    Vector3 targetVelocity; // 목표 속도
    float smoothTime = 0.1f; // 관성을 부드럽게 만들기 위한 시간 설정

    // Start is called before the first frame update
    void Start()
    {
        tracePlayer = GameManager.instance.player;
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVec = (tracePlayer.transform.position - trans.position).normalized;
        targetVelocity = moveVec * speed;
        if (hp <= 0)
        {
            anim.SetTrigger("Dead");
        }
    }

    private void FixedUpdate()
    {
        // 현재 속도를 부드럽게 조절하기
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Rigidbody에 속도 적용
        rigid.velocity = currentVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            anim.SetTrigger("Hit");
        }
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}