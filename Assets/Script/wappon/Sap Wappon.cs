
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapWappon : MonoBehaviour
{
    private float damage = 0.0f;
    private int per = 0;

    private void Init(){
        ConfigReader configreaders = new ConfigReader();
        configreaders.Initialize(configreaders.GetfilePath());
        configreaders.MakeDiction("Sap Wappon");
        damage = configreaders.ConvertToNumeric<float>(configreaders.GetDictionaryValue("damage")); ;
        per = configreaders.ConvertToNumeric<int>(configreaders.GetDictionaryValue("per")); ;




    }


    public float Getdamage()
    {
        return damage;
    }
}




