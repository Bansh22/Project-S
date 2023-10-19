using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternShoot : MonoBehaviour
{
    Rigidbody2D rigid;
    public float damage;
    private float start;
    private float timer=5;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        start = GameManager.instance.gameTime;
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.gameTime - start > timer)
        {
            Destroy(gameObject);
        }
    }
    public void Init(Vector3 dir,float speed,float damage)
    {
        this.damage = damage;
        rigid.velocity = dir*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.takeDamage(damage);
        }
    }

}
