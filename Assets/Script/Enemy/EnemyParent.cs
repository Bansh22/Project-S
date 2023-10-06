using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyParent : MonoBehaviour
{


    //Set ,Get 있는 친구들 , 꺼내오고 , 값을 수정하는 함수가 있다 
    private float speed;
    private float MaxHp;
    private float hp;
   
    private float damage;

    // Set, Get 이 있고 Change가 있는 함수, 
    private bool isLive;

     

    //TakeDamage 변수 : damage  받아서, hp를 깎는다 
    //hp 가 0보다 작으면  gameobject 를 비활성화 시킨다 
    public void takeDamage(float damage)
    {
        this.hp -= damage; // 데미지 받는다
        if (hp <= 0) //0보다 작으면 
        {
            gameObject.SetActive(false); // 게임 오브젝트르 비활성화 한다 
            setLive(false);
        }
    }
    //Revive 함수 , 변수를 hp 로 받아서 최대체력으로 현재 hp 를 만들어준다 
    
    public void Revive()
    {
        this.hp = this.MaxHp;
        gameObject.SetActive(true);
        setLive(true);
    }

    //Speed 관련 코드 
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public float getSpeed()
    {
        return this.speed;
    }

    //MaxHp 관련 코드 
    public void setMaxHp(float MaxHp)
    {
        this.MaxHp = MaxHp;
    }
    public float getMaxHp()
    {
        return this.MaxHp;
    }

    //Hp 관련 코드 
    public void setHp(float hp)
    {
        this.hp = hp;
    }
    public float getHp()
    {
        return this.hp;
    }
    //Damage 관련 코드 
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public float getDamage()
    {
        return this.damage;
    }
    // Live 관련 코드 
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
