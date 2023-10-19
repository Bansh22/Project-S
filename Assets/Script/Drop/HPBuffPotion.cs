using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유저의 최대체력을 늘린다.
public class HPBuffPotion : ItemParent
{
    private readonly ConfigReader reader;
    public HPBuffPotion()
    {
        reader = new ConfigReader("HPPotion");
        setLimit(reader.Search<int>("Limit"));
        setEffect(reader.Search<float>("Effect"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(false);
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
            player.HpBuff(getEffect());
            DeleteList(Drop_Manage.Drop.HP);
        }
    }
}
