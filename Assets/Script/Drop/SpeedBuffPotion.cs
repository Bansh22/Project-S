using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어의 속도를 증가시킨다.
public class SpeedBuffPotion : ItemParent
{
    private readonly ConfigReader reader;
    public SpeedBuffPotion()
    {
        reader = new ConfigReader("SpeedPotion");
        setLimit(reader.Search<int>("Limit"));
        setEffect(reader.Search<float>("Effect"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(true);
    }
    private void Awake()
    {

        childAnim = child.GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        color = render.material.color;
        startA = color.a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.SpeedBuff(getEffect());
            DeleteList(Drop_Manage.Drop.Speed);
        }
    }
}
