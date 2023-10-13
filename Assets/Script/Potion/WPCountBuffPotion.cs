using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPCountBuffPotion : MonoBehaviour
{
    ConfigReader reader;
    private float spawnChance;
    private void Awake()
    {
        reader = new ConfigReader("WPCountBuff");
        spawnChance = reader.Search<float>("Chance");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearing_Wappon_Manager weaponManager = collision.gameObject.GetComponentInChildren<nearing_Wappon_Manager>();
            weaponManager.CountUp();
            Destroy(gameObject);
        }
    }
}
