using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappon_Pool_Manager_Script : MonoBehaviour
{
    //������ ���� ���� 
    public GameObject[] Prefabs;

    List<GameObject>[] Wappon_Pools;

    public Transform[] WapponPoints;
    // Ǯ ����ϴ� ����Ʈ 
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
