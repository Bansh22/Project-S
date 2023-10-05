using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemyType0 : EnemyParent
{ 
    private GameObject mine;
    private ConfigReader reader;
    private Player tracePlayer;

    private Transform trans;
    private Rigidbody2D rigid;
    private SpriteRenderer render;
    private Animator anim;
    //a
    private Vector3 currentVelocity;
    private float smoothTime = 0.1f; // ������ �ε巴�� ����� ���� �ð� ����

    public EnemyType0()
    {
        reader = new ConfigReader("Enemy0");
        setSpeed(reader.Search<float>("speed"));
        setHp(reader.Search<float>("hp"));
        setDamage(reader.Search<float>("damage"));
        setLive(true);
    }
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
    public void playerTrace()
    {
        Vector3 targetVelocity; // ��ǥ �ӵ�
        Vector3 moveVec = (tracePlayer.transform.position - trans.position).normalized;
      
        targetVelocity = moveVec * getSpeed();
        // ���� �ӵ��� �ε巴�� �����ϱ�
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Rigidbody�� �ӵ� ����
        rigid.velocity = currentVelocity;
        render.flipX = moveVec.x < 0;
    }
}
