using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappon_Pool_Manager_Script : MonoBehaviour
{
    //프리펩 보관 변수 
    public GameObject[] Prefabs;

    List<GameObject>[] Wappon_Pools;

    public Transform[] WapponPoints;
    // 풀 담당하는 리스트 
    private void Awake()
    {
        Wappon_Pools = new List<GameObject>[Prefabs.Length];
        for (int index=0;index < Wappon_Pools.Length;index++)
        {
            Wappon_Pools[index]= new List<GameObject>();
        }
    }



    public GameObject GetPoolsPrefabs(int index) {

        GameObject Select = null;

       

        if(!Select)
        {
            Select = Instantiate(Prefabs[index], transform);
            Wappon_Pools[index].Add(Select);
        }

        return Select;
    }

}
