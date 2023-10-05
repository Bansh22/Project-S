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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SapWappon sappon = new SapWappon();
        if (!collision.gameObject.CompareTag("Bullet"))
            return;

        takeDamage(sappon.Getdamage());

        if (getHp() > 0)
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