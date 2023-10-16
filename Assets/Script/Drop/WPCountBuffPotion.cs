using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무기 개수를 늘린다.
public class WPCountBuffPotion : ItemParent
{
    private readonly ConfigReader reader;
    public WPCountBuffPotion()
    {
        reader = new ConfigReader("WPCountPotion");
        setLimit(reader.Search<int>("Limit"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearing_Wappon_Manager weaponManager = collision.gameObject.GetComponentInChildren<nearing_Wappon_Manager>();
            weaponManager.CountUp();
            DeleteList(Drop_Manage.Drop.WPCount);
            Destroy(gameObject);
        }
    }
}
