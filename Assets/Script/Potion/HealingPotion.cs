using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    ConfigReader reader;
    private float heal;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("Healing");
        heal = reader.Search<float>("Heal");
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.Healing(heal);
            Destroy(gameObject);
        }
    }
}
