using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Wisp : EnemyType1
{
    public Enemy1_Wisp()
    {
        //키 설정
        setKey("Enemy1_Wisp");
        //Enemy0 사전 열기
        reader = new ConfigReader("Enemy1_Wisp");
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
        //투사체 관련(데미지, 주기, 속도)
        setFireDamage(reader.Search<float>("FireDamage"));
        setFireRate(reader.Search<float>("FireRate"));
        setFireSpeed(reader.Search<float>("FireSpeed"));
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
}
