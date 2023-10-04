using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;


public class EnemyFuntion
{
    Player tracePlayer;
    Transform trans;
    Rigidbody2D rigid;
    SpriteRenderer render;
    Animator anim; 
    Vector3 currentVelocity;
    float speed;
    float smoothTime = 0.1f; // 관성을 부드럽게 만들기 위한 시간 설정
    public EnemyFuntion(GameObject obj)
    {
        anim = obj.GetComponent<Animator>();
        trans = obj.GetComponent<Transform>();
        rigid = obj.GetComponent<Rigidbody2D>();
        render = obj.GetComponent<SpriteRenderer>();
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void setTracePlayer(Player player)
    {
        this.tracePlayer = player;
    }
    public void  trace()
    {
        Vector3 targetVelocity; // 목표 속도
        Vector3 moveVec = (tracePlayer.transform.position - trans.position).normalized;

        targetVelocity = moveVec * speed;
        // 현재 속도를 부드럽게 조절하기
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Rigidbody에 속도 적용
        rigid.velocity = currentVelocity;
        render.flipX = moveVec.x < 0;
    }
}