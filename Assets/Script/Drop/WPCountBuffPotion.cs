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
    private void Awake()
    {
        Initialize();
        childAnim = child.GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        color = render.material.color;
        startA = color.a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearing_Wappon_Manager weaponManager = collision.gameObject.GetComponentInChildren<nearing_Wappon_Manager>();
            if (weaponManager != null)
            {
                weaponManager.CountUp();
            }
            DeleteList(Drop_Manage.Drop.WPCount);
        }
    }
}
