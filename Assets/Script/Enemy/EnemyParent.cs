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


    // Set, Get 이 있고 KnockBack가 있는 함수,
    private bool isKnock;
    WaitForFixedUpdate wait;

    //
    //TakeDamage 변수 : damage  받아서, hp를 깎는다 
    //hp 가 0보다 작으면  gameobject 를 비활성화 시킨다 
    //hp 가 0보다 크면 hit 애니메이션 작동 후 일정 거리 넉백한다.
    public void takeDamage(float damage)
    {
        this.hp -= damage; // 데미지 받는다

        Collider2D coll = this.gameObject.GetComponent<Collider2D>();
        Animator anim = gameObject.GetComponent<Animator>();
        if (isKnock)
        {
            StartCoroutine(KnockBack());
        }
        if (hp <= 0) //0보다 작으면 
        {
            //죽어있는 시체와의 상호작용 해제
            coll.enabled = false;
            
            
            this.gameObject.SetActive(false); // 게임 오브젝트르 비활성화 한다 
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
    
    //KnockBack 관련 함수
    public void setKnock(bool Knock)
    {
        this.isKnock = Knock;
    }
    public bool getKnock()
    {
        return this.isKnock;
    }
}
