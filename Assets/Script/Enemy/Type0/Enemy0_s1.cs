using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0_s1 : EnemyType0
{
    public Enemy0_s1()
    {
        //키 설정
        setKey("Enemy0_S1");
        //Enemy0 사전 열기
        reader = new ConfigReader("Enemy0_S1");
        //속도 설정
        Speed=reader.Search<float>("speed");
        //MaxHp 설정
        MaxHp=reader.Search<float>("hp");
        //Hp 설정
        Hp = getReader().Search<float>("hp");
        //주는 데미지 설정
        Damage = reader.Search<float>("damage");
        //리젠 시간
        setRegen(reader.Search<float>("regen"));
        //현재 살아있는 상태 설정
        IsLive = true;
    }
    // Start is called before the first frame updated
    private void Start()
    {
        //시작 설정 함수 실행
        startfun();
    }
    public void startfun()
    {
        Init();
        //넉백되는지 안되는지
        setKnock(true);
        //넉백되는 정도
        setKnockForce(2);
        //object 기본 세팅
        setObject();
        //보는 방향(주의:playerTrace 보다 위에 존재해야한다.)
        setStartFilpX(getSpriteRenderer().flipX);
        //플레이어 추적 대상 설정
        setTracePlayer(GameManager.instance.player);
        //플레이어 추적
        playerTrace();
    }
    // Update is called once per frame
    void Update()
    {
    }

    
  
}