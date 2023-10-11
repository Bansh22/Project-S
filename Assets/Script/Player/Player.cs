using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerParent
{
    ConfigReader reader;
    public Vector3 inputVec;
    public Player()
    {
        //Enemy0 사전 열기
        reader = new ConfigReader("Player");
        //속도 설정
        setSpeed(reader.Search<float>("speed"));
        //MaxHp 설정
        setMaxHp(reader.Search<float>("hp"));
        //Hp 설정
        setHp(reader.Search<float>("hp"));
        //현재 살아있는 상태 설정
        setLive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        //시작 설정 함수 실행
        startfun();
    }
    public void startfun()
    {
        //넉백되는지 안되는지
        setKnock(false);
        //object 기본 세팅
        setObject();
    }
    // Update is called once per frame

    void Update()
    {
        if (!getLive())
        {
            inputVec = Vector3.zero;
            return;
        }
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //Raw의 경우 0,1로 이진값으로 바꿔주는 장치
    }

    private void FixedUpdate()
    {
        getAnimator().SetFloat("Speed", inputVec.magnitude);

        Vector3 nextVec = inputVec.normalized * getSpeed() * Time.fixedDeltaTime;
        //합산된 벡터 계산, normalized의 경우 x,y 벡터의 합이 1이상이 되기때문에 1로 고정
        //fixedDeltaTime의 경우 달라지는 프레임 대비
        getTransform().Translate(nextVec);
        getSpriteRenderer().flipX = inputVec.x <= 0;

        //위치 이동

        getRigidbody2D().velocity = Vector3.zero;

    }
    
}
