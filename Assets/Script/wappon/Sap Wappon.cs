
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapWappon : MonoBehaviour
{

  

    public void Init(){
        ConfigReader configreaders = new ConfigReader();

        configreaders.Initialize(configreaders.GetfilePath());

       /*

        if (sapData.ContainsKey("damage"))
        {
            if (float.TryParse(sapData["damage"], out float damageValue))
            {
                float damage = damageValue;
                Debug.Log("damage: " + damage);
            }
        }
        if (sapData.ContainsKey("per"))
        {
            if (int.TryParse(sapData["per"], out int perValue))
            {
                int per = perValue;
                Debug.Log("per: " + per);
            }
        }
       */


    }
}




