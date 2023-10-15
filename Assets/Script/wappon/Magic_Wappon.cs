using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Wappon : Wappon
{
    private ConfigReader reader;

    private int per;


    public void Init(float damage, int per)
    {

        this.per = per;
        this.damage = damage;
    }


  


}



