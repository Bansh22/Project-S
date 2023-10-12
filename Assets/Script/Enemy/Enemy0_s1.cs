using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_s1 : EnemyType0
{
    //사전 클래스
    private readonly ConfigReader reader;
    public Enemy0_s1()
    {
        //Enemy0 사전 열기
        reader = new ConfigReader("Enemy0_S1");
        //속도 설정
        setSpeed(reader.Search<float>("speed"));
        //MaxHp 설정
        setMaxHp(reader.Search<float>("hp"));
        //Hp 설정
        setHp(reader.Search<float>("hp"));
        //주는 데미지 설정
        setDamage(reader.Search<float>("damage"));
        //리젠 시간
        setRegen(reader.Search<float>("regen"));
        //현재 살아있는 상태 설정
        setLive(true);
    }
    // Start is called before the first frame updated
    private void Start()
    {
        //시작 설정 함수 실행
        startfun();
    }
    public void startfun()
    {
        //넉백되는지 안되는지
        setKnock(true);
        //넉백되는 정도
        setKnockForce(2);
        //object 기본 세팅
        setObject();
        //플레이어 추적 대상 설정
        setTracePlayer(GameManager.instance.player);
        //플레이어 추적
        playerTrace();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //죽어있으면 작동정지 || Hit 태그 가진 애니메이션 끝날때 까지 작동 정지
        if (!getLive() || getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            return;
        }
        //추적 대상 설정
        setTracePlayer(GameManager.instance.player);
        //플레이어 추적
        playerTrace();
    }

    //접촉 코드(무기 데미지 충돌) #삽이 트리거로 작동되고 있음
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌 대상이 총알 아닐때 이벤트 종료 || 살아있을때 || 히트애니메이션가 유지되지않을때
        if (!collision.gameObject.CompareTag("Bullet")||!getLive()|| getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            return;
        //충돌 대상의 Component에서 스크립트 소환 #아 삽한정으로 하면안되지 #수정필요
        SapWappon collisuonWappon = collision.gameObject.GetComponent<SapWappon>();

        GameManager.instance.AudioManager.PlaySfx(AudioManageer.Sfx.Hit);
        
        //데미지 부여
        takeDamage(collisuonWappon.Getdamage());
    }


    private void OnEnable()
    {
        //다시 나타날때 추적대상 설정
        setTracePlayer(GameManager.instance.player);
    }
  
}