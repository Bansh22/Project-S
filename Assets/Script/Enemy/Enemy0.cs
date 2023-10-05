using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    EnemyFuntion funtion;
    ConfigReader data;

    float speed;
    float hp;
    float damage;
    bool isLive = true;
    Vector3 moveVec;
    Vector3 currentVelocity; // 
    Vector3 targetVelocity; // 

    // Start is called before the first frame updated
    void Start()
    {
        data = new ConfigReader("Enemy0");
        speed = data.Search<float>("speed");
        hp= data.Search<float>("hp");
        damage= data.Search<float>("damage");
        Debug.Log(damage);

        funtion = new EnemyFuntion(gameObject);
        funtion.setTracePlayer(GameManager.instance.player);
        funtion.setSpeed(speed);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            //anim.SetTrigger("Dead");
            isLive = false;
        }
        if (!isLive)
            return;

        funtion.trace();    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SapWappon sappon = new SapWappon();
        if (!collision.gameObject.CompareTag("Bullet"))
            return;

        hp -= sappon.Getdamage();

        if (hp > 0)
        {

        }
        else
        {
            //Dead();
        }

    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}