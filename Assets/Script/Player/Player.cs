using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Transform trans;
    public float speed;
    public Vector2 inputVec;
    Animator anim;

    // Start is called before the first frame update
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Start()
    {

        trans = GetComponent<Transform>();
        //sprite�� ������ Ư�� (��ġ ũ�� ȸ��)
        anim = GetComponent<Animator>();
       
    }
    // Update is called once per frame
   

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //�ջ�� ���� ���, normalized�� ��� x,y ������ ���� 1�̻��� �Ǳ⶧���� 1�� ����
        //fixedDeltaTime�� ��� �޶����� ������ ���
        rigid.MovePosition(rigid.position + nextVec);
        trans.Translate(nextVec);
        //��ġ �̵�
    }


    void OnMove(InputValue val){
        inputVec = val.Get<Vector2>();
    }
}
