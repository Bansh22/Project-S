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
    private float smoothTime = 0.1f; // ������ �ε巴�� ����� ���� �ð� ����
    
    public void setObject()
    {
        this.mine = gameObject;
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
            setObject();
        }
        Vector3 targetVelocity; // ��ǥ �ӵ�
        Vector3 moveVec = (tracePlayer.transform.position - trans.position).normalized;
      

        targetVelocity = moveVec * getSpeed();
        // ���� �ӵ��� �ε巴�� �����ϱ�
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);
        // Rigidbody�� �ӵ� ����
        rigid.MovePosition(currentVelocity * Time.fixedDeltaTime + trans.position);
        rigid.velocity = Vector3.zero;

        //����Ʈ �̵�
        //trans.Translate(moveVec * getSpeed() * Time.fixedDeltaTime);
        render.flipX = moveVec.x < 0;

    }
    public Animator getAnimator()
    {
        return this.anim;
    }
}
