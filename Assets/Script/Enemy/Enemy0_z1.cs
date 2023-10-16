using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_z1 : EnemyType0
{
    //사전 클래스
    private readonly ConfigReader reader;
    public Enemy0_z1()
    {
        //Enemy0 사전 열기
        reader = new ConfigReader("Enemy0_Z1");
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
        //보는 방향
        setStartFilpX(getSpriteRenderer().flipX);
    }
    // Update is called once per frame
  

  

    //접촉 코드(무기 데미지 충돌) #삽이 트리거로 작동되고 있음

  
  
}