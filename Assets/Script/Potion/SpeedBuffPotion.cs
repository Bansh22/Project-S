using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffPotion : MonoBehaviour
{
    ConfigReader reader;
    private float buff;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("SpeedBuff");
        buff = reader.Search<float>("Buff");
        buff = 0.2f;
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.SpeedBuff(buff);
            Destroy(gameObject);
        }
    }
}
