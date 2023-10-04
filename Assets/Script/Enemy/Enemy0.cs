using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrace : MonoBehaviour
{
    Player tracePlayer;
    Animator anim;
    Transform trans;
    Rigidbody2D rigid;

    float speed = 2.5f;
    int hp = 100;
    int damage = 10;
    Vector3 moveVec;
    Vector3 currentVelocity; // ���� �ӵ�
    Vector3 targetVelocity; // ��ǥ �ӵ�
    float smoothTime = 0.1f; // ������ �ε巴�� ����� ���� �ð� ����

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
    }

    private void FixedUpdate()
    {
        // ���� �ӵ��� �ε巴�� �����ϱ�
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);

        // Rigidbody�� �ӵ� ����
        rigid.velocity = currentVelocity;
    }
}