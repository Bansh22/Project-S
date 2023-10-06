using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : EnemyType0
{

    // Start is called before the first frame updated
    void Start()
    {
        setObject(gameObject);
        setTracePlayer(GameManager.instance.player);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (getHp() <= 0)
        {
            //anim.SetTrigger("Dead");
            setLive(false);
        }
        if (!getLive())
            return;

        playerTrace();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Bullet"))
        {
            return;
        }

        SapWappon sapWappon = collision.GetComponent<SapWappon>();

        // "SapWappon" ��ũ��Ʈ�� �����ϴ� ���
        if (sapWappon != null)
        {
            // "SapWappon" ��ũ��Ʈ�� Getdamage() �Լ��� ȣ���Ͽ� Damage ���� ��������
            float damage = sapWappon.Getdamage();

            // ���� 'damage' ������ ������ ���� ����Ǿ����Ƿ� ���ϴ� �۾��� ������ �� ����
            takeDamage(damage);

            // �������� ��� ó������ ���⿡ �߰� �۾��� ����
        }
    }
    

    private void OnEnable()
    {
        setTracePlayer(GameManager.instance.player);
    }
}