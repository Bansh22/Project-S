using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject MobHPs;

    public void addUI(int prefabNum, GameObject par)
    {
        if (Prefabs.Length == 0)
        {
            Debug.Log("UIManager Not Setting");
            return;
        }
        GameObject uiObj = Instantiate(Prefabs[prefabNum], transform);
        uiObj.transform.SetParent(MobHPs.transform);
        FollowUI followUI=uiObj.GetComponent<FollowUI>();
        followUI.target = par;
        followUI.followTarget(par);
        //Transform healthSliderTransform = uiObj.transform.Find("Health_Slider");
        //Transform hptextTransform = uiObj.transform.Find("Hptext");

        //if (hptextTransform != null)
        //{
        //    // Destroy the Hptext
        //    Destroy(hptextTransform.gameObject);
        //}
    }
}
