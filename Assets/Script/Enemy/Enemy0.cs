using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : EnemyType0
{

    // Start is called before the first frame updated
    void Start()
    {
        setObject(gameObject);
        setTracePlayer(GameManager.instance.player);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (getHp() <= 0)
        {
            //anim.SetTrigger("Dead");
            setLive(false);
        }
        if (!getLive())
            return;

        playerTrace();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Bullet"))
        {
            return;
        }

        SapWappon sapWappon = collision.GetComponent<SapWappon>();

        // "SapWappon" 스크립트가 존재하는 경우
        if (sapWappon != null)
        {
            // "SapWappon" 스크립트의 Getdamage() 함수를 호출하여 Damage 변수 가져오기
            float damage = sapWappon.Getdamage();

            // 이제 'damage' 변수에 데미지 값이 저장되었으므로 원하는 작업을 수행할 수 있음
            takeDamage(damage);

            // 데미지를 어떻게 처리할지 여기에 추가 작업을 수행
        }
    }
    

    private void OnEnable()
    {
        setTracePlayer(GameManager.instance.player);
    }
}