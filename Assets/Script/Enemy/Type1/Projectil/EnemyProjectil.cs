using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 투사체의 경우 tag를 이용해서 데미지를 준다.
/// 
/// </summary>
public class EnemyProjectil : MonoBehaviour
{
    Rigidbody2D rigid;
    private float damage;
    float timer;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }
    public void Init(float damage,Vector3 dir, float speed){
        this.damage = damage;
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        GameManager.instance.player.takeDamage(damage);
        Destroy(gameObject);
    }



}