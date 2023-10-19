using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유저의 현재 체력을 증가시킨다.
public class HealingPotion : ItemParent
{
    private readonly ConfigReader reader;
    private bool oneTime=false;
    public HealingPotion()
    {
        reader = new ConfigReader("HealPotion");
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
        if (collision.gameObject.CompareTag("Player") && !oneTime)
        {
            oneTime = true;
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.Healing(getEffect());
            DeleteList(Drop_Manage.Drop.Heal);
        }
    }
}
