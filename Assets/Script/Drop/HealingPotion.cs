using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유저의 현재 체력을 증가시킨다.
public class HealingPotion : ItemParent
{
    private readonly ConfigReader reader;

    public HealingPotion()
    {
        reader = new ConfigReader("HealPotion");
        setLimit(reader.Search<int>("Limit"));
        setEffect(reader.Search<float>("Effect"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.Healing(getEffect());
            DeleteList(Drop_Manage.Drop.Heal);
            Destroy(gameObject);
        }
    }
}
