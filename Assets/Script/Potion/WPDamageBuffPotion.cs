using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPDamageBuffPotion : MonoBehaviour
{
    ConfigReader reader;
    private float buff;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("WPDamageBuff");
        buff = reader.Search<float>("buff");
        buff = 20;
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearing_Wappon_Manager weaponManager = collision.gameObject.GetComponentInChildren<nearing_Wappon_Manager>();
            weaponManager.DamageUp(buff);
            Destroy(gameObject);
        }
    }
}
