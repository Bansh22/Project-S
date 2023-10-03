using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform trans;
    public float speed;
    public Vector3 inputVec;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        trans = GetComponent<Transform>();
        //sprite�� ������ Ư�� (��ġ ũ�� ȸ��)
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //Raw�� ��� 0,1�� ���������� �ٲ��ִ� ��ġ
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        Vector3 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //�ջ�� ���� ���, normalized�� ��� x,y ������ ���� 1�̻��� �Ǳ⶧���� 1�� ����
        //fixedDeltaTime�� ��� �޶����� ������ ���
        trans.Translate(nextVec);
        //��ġ �̵�
    }
}
