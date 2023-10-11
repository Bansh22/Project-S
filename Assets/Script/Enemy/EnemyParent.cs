using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyParent : MonoBehaviour
{
    //컴포넌트 기능 Get함수로 반환
    private GameObject mine;
    private Transform trans;
    private Rigidbody2D rigid;
    private SpriteRenderer render;
    private Animator anim;
    private Collider2D coll;

    //Set ,Get 있는 친구들 , 꺼내오고 , 값을 수정하는 함수가 있다 
    private float speed;
    private float MaxHp;
    private float hp;
    private bool hpBar=true;
    
    private float damage;

    // Set, Get 이 있고 Change가 있는 함수, 
    private bool isLive;

    // Set, Get 이 있고 KnockBack와 관련 있는 함수,
    private bool isKnock;//넉백
    private float KnockForce;
    WaitForFixedUpdate wait;

    public GameObject gemPrefab;
    //오브젝트 계층
    private int order;


    private float fixedProbability = 0.5f;

    //TakeDamage 변수 : damage  받아서, hp를 깎는다 
    //hp 가 0보다 작으면  gameobject 를 비활성화 시킨다 
    //hp 가 0보다 크면 hit 애니메이션 작동 후 일정 거리 넉백한다.
    public void takeDamage(float damage)
    {
        hp -= damage; // 데미지 받는다

        //변수에 따라 넉백 작동
        
        if (hp <= 0) //0보다 작으면 
        {
            order = render.sortingOrder;
            setLive(false);
            anim.SetTrigger("Dead");
            render.sortingOrder = order-1;// 시체가 몹가리는거 방지
            coll.enabled=false;//시체 충돌 무시
            StartCoroutine(Dead());
            
        }else if (hp > 0)
        {
            //첫 타격에만 생성
            if (hpBar)
            {
                //hpBar 생성
                GameManager.instance.uiManger.addUI(0, gameObject);
                hpBar = false;//타격이후 생성 차단
            }

            //hit 애니메이션 작동
            anim.SetTrigger("Hit");
            if (isKnock)
            {
                //코루틴 작동
                StartCoroutine(KnockBack());
            }
        }
    }
    //코루틴으로 넉백 작동
    //현재 유저 위치와 반대로 밀림
    //KnockForce로 밀리는 정도 조절가능

    IEnumerator KnockBack()
    {
        //FixedUpdate 시간 만큼 정지
        yield return wait;
        //플레이어 위치
        Vector3 plyPos = GameManager.instance.player.transform.position;
        //현 위치 - 플레이어 위치
        Vector3 dirVec = transform.position - plyPos;
        //물리 컴포넌트
        //ForceMode2D.Impulse으로 순간적인 힘 적용
        rigid.AddForce(dirVec.normalized * KnockForce, ForceMode2D.Impulse);
    }

    IEnumerator Dead()
    {
        rigid.velocity = Vector3.zero;
        GameManager.instance.catchEnemy++;
        yield return wait;
        while (!(anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=3))
        {
            yield return wait;
        }
        if (gemPrefab != null)
        {
            float randomValue = Random.Range(0f, 100f);
            if (randomValue <= fixedProbability) { 
                Instantiate(gemPrefab, transform.position, Quaternion.identity);
            }
        }
        this.gameObject.SetActive(false); // 게임 오브젝트르 비활성화 한다 
    }


    //Revive 함수 , 변수를 hp 로 받아서 최대체력으로 현재 hp 를 만들어준다 

    public void Revive()
    {
        this.hp = this.MaxHp;
        render.sortingOrder = order;// 살아나면서 order 증가
        anim.SetTrigger("Live");
        gameObject.SetActive(true);
        coll.enabled = true;//충돌 허용
        hpBar = true;//hpBar 생성허용
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
    public void setKnockForce(float KnockForce)
    {
        this.KnockForce = KnockForce;
    }
    public float getKnockForce()
    {
        return this.KnockForce;
    }

    //컴포넌트 설정
    public void setObject()
    {
        //컴포넌트 설정되어있는 확인용
        mine = gameObject;
        //벡터 컴포넌트
        trans = gameObject.GetComponent<Transform>();
        //애니메 컴포넌트
        anim = gameObject.GetComponent<Animator>();
        //랜더 컴포넌트
        render = gameObject.GetComponent<SpriteRenderer>();
        //물리 컴포넌트
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //충돌 컴포넌트
        coll = gameObject.GetComponent<Collider2D>();
    }
    public Transform getTransform()
    {
        return trans;
    }
    public Animator getAnimator()
    {
        return anim;
    }
    public SpriteRenderer getSpriteRenderer()
    {
        return render;
    }
    public Rigidbody2D getRigidbody2D()
    {
        return rigid;
    }
    public Collider2D getCollider2D()
    {
        return coll;
    }
}
    