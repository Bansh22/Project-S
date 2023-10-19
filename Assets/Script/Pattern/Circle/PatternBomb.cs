using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBomb : MonoBehaviour
{
    Transform trans;
    Player player;
    CircleCollider2D coll;
    Animator anim;
    float damage=60;
    bool oneTime = false;
    public GameObject parent;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        coll = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        player = GameManager.instance.player;
    }
    private void FixedUpdate()
    {
        coll.radius = anim.GetCurrentAnimatorStateInfo(0).normalizedTime * trans.localScale.x / 2;
        if (coll.radius >= trans.localScale.x/2)
        {
            Destroy(parent);
        }
    }
    public void Init(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            //중심에 떨어질수록 약해지는 트리거 데미지 원래 데미지의 최대 50%까지 약해짐
            float rangeDamage =damage *( 1-(coll.radius / (trans.localScale.x / 2))/2);
            player.takeDamage(rangeDamage);
            Destroy(parent);
        }
    }
}
