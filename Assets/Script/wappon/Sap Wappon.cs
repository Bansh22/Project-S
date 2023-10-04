
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapWappon : MonoBehaviour
{

    private Dictionary<string, Dictionary<string, string>> configData;

    public void Init(){
        ConfigReader configreader = new ConfigReader();

        ConfigReader.Initialize(configreader.GetfilePath());

        Dictionary<string, string> sapData = configreader.GetDiction("Sap Wappon");

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


    }
}




