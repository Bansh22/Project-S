using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : EnemyType0
{
    private readonly ConfigReader reader;
    public Enemy0()
    {
        reader = new ConfigReader("Enemy0");
        setSpeed(reader.Search<float>("speed"));
        setMaxHp(reader.Search<float>("hp"));
        setHp(reader.Search<float>("hp"));
        setDamage(reader.Search<float>("damage"));
        setLive(true);
    }
    // Start is called before the first frame updated
    private void Start()
    {
        startfun();
    }
    public void startfun()
    {
        setKnock(true);
        setObject();
        setTracePlayer(GameManager.instance.player);
        playerTrace();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        if (!getLive() || getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        { 
            return;
        }
        setTracePlayer(GameManager.instance.player);
        playerTrace();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("Bullet"))
            return;

        SapWappon collisuonWappon = collision.gameObject.GetComponent<SapWappon>();

        GameManager.instance.AudioManager.PlaySfx(AudioManageer.Sfx.Hit);
        takeDamage(collisuonWappon.Getdamage());


    }


    private void OnEnable()
    {
        setTracePlayer(GameManager.instance.player);
    }
  
}