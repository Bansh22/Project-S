using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuffPotion : MonoBehaviour
{
    ConfigReader reader;
    private float buff;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("HPBuff");
        buff = reader.Search<float>("buff");
        buff = 20;
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerParent player = collision.gameObject.GetComponent<PlayerParent>();
            player.HpBuff(buff);
            Destroy(gameObject);
        }
    }
}
