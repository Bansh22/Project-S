using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager_Script : MonoBehaviour
{
    //������ ���� ���� 
    public GameObject[] Prefabs;

    List<GameObject>[] Pools;

    // Ǯ ����ϴ� ����Ʈ 
    private void Awake()
    {
        Pools = new List<GameObject>[Prefabs.Length];
        for (int index=0;index < Pools.Length;index++)
        {
            Pools[index]= new List<GameObject>();
        }
    }


    //������, �� �����̺� �ڵ� 

    public GameObject GetPoolsPrefabs(int index) {

        GameObject Select = null;

        //�׾������� �츰�� 
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
