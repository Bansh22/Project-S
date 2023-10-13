
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapWappon : MonoBehaviour
{
    private ConfigReader reader;
    private float damage;
   

    public void Init(float damage){
        this.damage = damage;
    }


    public float Getdamage()
    {
        return damage;
    }

   
}




