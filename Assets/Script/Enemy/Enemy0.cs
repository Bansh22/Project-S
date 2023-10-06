using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : EnemyType0
{
    private readonly ConfigReader reader;

    public Enemy0()
    {
        reader = new ConfigReader("Enemy0");
        setSpeed(reader.Search<float>("speed"));
        setMaxHp(reader.Search<float>("hp"));
        setHp(reader.Search<float>("hp"));
        setDamage(reader.Search<float>("damage"));
        setLive(true);
    }
    // Start is called before the first frame updated
    private void Start()
    {
        startfun();
    }
    public void startfun()
    {
        setObject(gameObject);
        setTracePlayer(GameManager.instance.player);
        playerTrace();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        if (!getLive())
        {
           
            return;
        }
        setTracePlayer(GameManager.instance.player);
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