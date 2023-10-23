using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//무기 속도 값을 증가 시킨다.
public class WPSpeedBuffPotion : ItemParent
{
    private readonly ConfigReader reader;
    public WPSpeedBuffPotion()
    {
        reader = new ConfigReader("WPSpeedPotion");
        setLimit(reader.Search<int>("Limit"));
        setEffect(reader.Search<float>("Effect"));
        setChance(reader.Search<float>("Chance"));
        setWorldLimit(true);
    }
    private void Awake()
    {

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
                weaponManager.SpeedUp(getEffect());
            }
            DeleteList(Drop_Manage.Drop.WPSpeed);
        }
    }
}
