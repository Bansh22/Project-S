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

     

    //TakeDamage ���� : damage  �޾Ƽ�, hp�� ��´� 
    //hp �� 0���� ������  gameobject �� ��Ȱ��ȭ ��Ų�� 
    public void takeDamage(float damage)
    {
        this.hp -= damage; // ������ �޴´�
        if (hp <= 0) //0���� ������ 
        {
            gameObject.SetActive(false); // ���� ������Ʈ�� ��Ȱ��ȭ �Ѵ� 
            setLive(false);
        }
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

}
