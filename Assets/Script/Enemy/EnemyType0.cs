using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemyType0 : EnemyParent
{ 
    private GameObject mine;
    private Player tracePlayer;

    private Transform trans;
    private Rigidbody2D rigid;
    private SpriteRenderer render;
    private Animator anim;

    private Vector3 currentVelocity;
    private float smoothTime = 0.1f; // 관성을 부드럽게 만들기 위한 시간 설정

  
    public void setObject(GameObject obj)
    {
        this.mine = obj;
        anim    = mine.GetComponent<Animator>();
        trans   = mine.GetComponent<Transform>();
        rigid   = mine.GetComponent<Rigidbody2D>();
        render  = mine.GetComponent<SpriteRenderer>();
    }
    
    public void setTracePlayer(Player player)
    {
        this.tracePlayer = player;
    }
    public Player getTarget()
    {
        return this.tracePlayer;
    }
    public void playerTrace()
    {
        if (!mine)
        {
            setObject(gameObject);
        }
        Vector3 targetVelocity; // 목표 속도
        Vector3 moveVec = (tracePlayer.transform.position - trans.position).normalized;
      

        targetVelocity = moveVec * getSpeed();
        // 현재 속도를 부드럽게 조절하기
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Rigidbody에 속도 적용
        rigid.velocity = currentVelocity;
        render.flipX = moveVec.x < 0;
         
    }
}
