using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] Prefabs;


    public void addUI(int prefabNum, GameObject parent)
    {
        if (Prefabs.Length == 0)
        {
            Debug.Log("UIManager Not Setting");
            return;
        }
        GameObject uiObj= Instantiate(Prefabs[prefabNum], transform);
        FollowUI followUI=uiObj.GetComponent<FollowUI>();
        followUI.target = parent;
    }
}