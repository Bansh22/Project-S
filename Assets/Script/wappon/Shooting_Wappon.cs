
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Wappon: MonoBehaviour
{
    private ConfigReader reader;
    private float damage;
    private int per;
   

    public void Init(float damage, int per){

        this.per = per;
        this.damage = damage;
    }


    public float Getdamage()
    {
        return damage;
    }

   
}




