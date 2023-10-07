using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyParent : MonoBehaviour
{

    //Set ,Get �ִ� ģ���� , �������� , ���� �����ϴ� �Լ��� �ִ� 
    private float speed;
    private float MaxHp;
    private float hp;
   
    private float damage;

    // Set, Get �� �ְ� Change�� �ִ� �Լ�, 
    private bool isLive;


    // Set, Get �� �ְ� KnockBack�� �ִ� �Լ�,
    private bool isKnock;
    WaitForFixedUpdate wait;

    //
    //TakeDamage ���� : damage  �޾Ƽ�, hp�� ��´� 
    //hp �� 0���� ������  gameobject �� ��Ȱ��ȭ ��Ų�� 
    //hp �� 0���� ũ�� hit �ִϸ��̼� �۵� �� ���� �Ÿ� �˹��Ѵ�.
    public void takeDamage(float damage)
    {
        this.hp -= damage; // ������ �޴´�

        Collider2D coll = this.gameObject.GetComponent<Collider2D>();
        Animator anim = gameObject.GetComponent<Animator>();
        if (isKnock)
        {
            StartCoroutine(KnockBack());
        }
        if (hp <= 0) //0���� ������ 
        {
            //�׾��ִ� ��ü���� ��ȣ�ۿ� ����
            coll.enabled = false;
            
            
            this.gameObject.SetActive(false); // ���� ������Ʈ�� ��Ȱ��ȭ �Ѵ� 
            setLive(false);
        }else if (hp > 0)
        {
            anim.SetTrigger("Hit");
        }
    }
    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 plyPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - plyPos;
        Rigidbody2D rigid= gameObject.GetComponent<Rigidbody2D>();
        rigid.AddForce(dirVec.normalized * 2, ForceMode2D.Impulse);
    }


    //Revive �Լ� , ������ hp �� �޾Ƽ� �ִ�ü������ ���� hp �� ������ش� 
    
    public void Revive()
    {
        this.hp = this.MaxHp;
        gameObject.SetActive(true);
        setLive(true);
    }

    //Speed ���� �ڵ� 
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public float getSpeed()
    {
        return this.speed;
    }

    //MaxHp ���� �ڵ� 
    public void setMaxHp(float MaxHp)
    {
        this.MaxHp = MaxHp;
    }
    public float getMaxHp()
    {
        return this.MaxHp;
    }

    //Hp ���� �ڵ� 
    public void setHp(float hp)
    {
        this.hp = hp;
    }
    public float getHp()
    {
        return this.hp;
    }
    //Damage ���� �ڵ� 
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public float getDamage()
    {
        return this.damage;
    }
    // Live ���� �ڵ� 
    public void setLive(bool live)
    {
        this.isLive = live;
    }
    public bool getLive()
    {
        return this.isLive;
    }

    public void ChangeLive()
    {
        isLive = !isLive;
    }
    
    //KnockBack ���� �Լ�
    public void setKnock(bool Knock)
    {
        this.isKnock = Knock;
    }
    public bool getKnock()
    {
        return this.isKnock;
    }
}
