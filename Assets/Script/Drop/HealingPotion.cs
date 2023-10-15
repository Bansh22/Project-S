using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : ItemParent
{
    ConfigReader reader;
    private float heal;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("Healing");
        heal = reader.Search<float>("Heal");
        heal = 20;
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.Healing(heal);
            DeleteList();
            Destroy(gameObject);
        }
    }
}
