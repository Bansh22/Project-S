using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager_Script : MonoBehaviour
{
    //프리펩 보관 변수 
    public GameObject[] Prefabs;

    List<GameObject>[] Pools;

    // 풀 담당하는 리스트 
    private void Awake()
    {
        Pools = new List<GameObject>[Prefabs.Length];
        for (int index=0;index < Pools.Length;index++)
        {
            Pools[index]= new List<GameObject>();
        }
    }


    //폴생성, 및 리바이브 코드 

    public GameObject GetPoolsPrefabs(int index) {

        GameObject Select = null;

        //죽어있으면 살린다 
        foreach(GameObject item in Pools[index])
        {
            if (!item.activeSelf)
            {
                Select = item;
               

                Select.GetComponent<Enemy0>().Revive();
               
                break;
            }

        }

        if(!Select)
        {
            Select = Instantiate(Prefabs[index], transform);
            Pools[index].Add(Select);
        }

        return Select;
    }
}
