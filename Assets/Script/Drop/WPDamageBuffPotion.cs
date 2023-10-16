using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무기 데미지를 강화한다.
public class WPDamageBuffPotion : ItemParent
{
    private readonly ConfigReader reader;
    public WPDamageBuffPotion()
    {
        reader = new ConfigReader("WPDamagePotion");
        setLimit(reader.Search<int>("Limit"));
        setEffect(reader.Search<float>("Effect"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearing_Wappon_Manager weaponManager = collision.gameObject.GetComponentInChildren<nearing_Wappon_Manager>();
            weaponManager.DamageUp(getEffect());
            DeleteList(Drop_Manage.Drop.WPDamage);
            Destroy(gameObject);
        }
    }
}
