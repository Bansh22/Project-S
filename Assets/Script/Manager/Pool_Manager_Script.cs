using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager_Script : MonoBehaviour
{
    //프리펩 보관 변수 
    public GameObject[] Prefabs;

    List<GameObject>[] Pools;

    //강화 주기 변수
    float pageTime = 0;
    float pageCatch = 0;
    public float lineTime = 30;
    public float lineCatch = 100;

    // 풀 담당하는 리스트 
    private void Awake()
    {
        Pools = new List<GameObject>[Prefabs.Length];
        for (int index=0;index < Pools.Length;index++)
        {
            Pools[index]= new List<GameObject>();
        }
        for (int i = 0; i < Prefabs.Length; i++)
        {
            EnemyParent enemyInfo;
            if (Prefabs[i].TryGetComponent<EnemyParent>(out enemyInfo))
            {
                enemyInfo.Init();
            }
        }
    }
    private void FixedUpdate()
    {
        //몹 변경 코드(시간)
        if (pageTime > GameManager.instance.gameTime % lineTime)
        {
            pageTime = 0;
            for (int i = 0; i < Prefabs.Length; i++)
            {
                EnemyParent enemyInfo;
                if (Prefabs[i].TryGetComponent<EnemyParent>(out enemyInfo))
                {
                    enemyInfo.setRegen(enemyInfo.getRegen() * (1 - 0.2f));
                }
            }
            pageTime = GameManager.instance.gameTime % lineTime;
            GameManager.instance.Level2++;
        }
        else
        {
            pageTime = GameManager.instance.gameTime % lineTime;
        }

        //몹 강화 코드(시간)
        if (pageTime > GameManager.instance.gameTime % lineTime)
        {
            pageTime = 0;
            for(int i = 0; i < Prefabs.Length; i++)
            {
                EnemyParent enemyInfo;
                if (Prefabs[i].TryGetComponent<EnemyParent>(out enemyInfo))
                {
                    enemyInfo.setRegen(enemyInfo.getRegen() * (1 - 0.2f));
                }
            }
            pageTime = GameManager.instance.gameTime % lineTime;
            GameManager.instance.Level2++;
        }
        else
        {
            pageTime = GameManager.instance.gameTime % lineTime;
        }

        //몹 강화 코드(잡은 수)
        if (pageCatch > GameManager.instance.catchEnemy % lineCatch)
        {
            for (int i = 0; i < Prefabs.Length; i++)
            {
                EnemyType1 type1;
                if(Prefabs[i].TryGetComponent<EnemyType1>(out type1))
                {
                    type1.Damage=type1.Damage * (1 + 0.2f);
                    type1.setFireDamage(type1.getFireDamage()* (1 + 0.2f));
                }
                EnemyType0 type0;
                if(Prefabs[i].TryGetComponent<EnemyType0>(out type0))
                {
                    type0.Damage=type0.Damage * (1 + 0.2f);
                }
                //이미 스폰된 몹 데미지 수정
                foreach(GameObject obj in Pools[i])
                {
                    EnemyType1 enemy_type1;
                    if (obj.TryGetComponent<EnemyType1>(out enemy_type1))
                    {
                        enemy_type1.Damage=type1.Damage;
                        enemy_type1.setFireDamage(type1.getFireDamage());
                    }
                    EnemyType0 enemy_type0;
                    if (obj.TryGetComponent<EnemyType0>(out enemy_type0))
                    {
                        enemy_type0.Damage=type0.Damage;
                    }
                }
            }
            GameManager.instance.Level1++;
            pageCatch = GameManager.instance.catchEnemy % lineCatch;
        }
        else
        {
            pageCatch = GameManager.instance.catchEnemy % lineCatch;
        }
    }

    //폴생성, 및 리바이브 코드 

    public GameObject GetPoolsPrefabs(int index,Vector3 position) {

        GameObject Select = null;

        //죽어있으면 살린다 
        foreach(GameObject item in Pools[index])
        {
            if (!item.activeSelf)
            {
                Select = item;
                

                Select.GetComponent<EnemyParent>().Revive();
                Select.transform.position = position;
                break;
            }

        }

        if(!Select)
        {
            Select = Instantiate(Prefabs[index], transform);
            Select.transform.position = position;
            Pools[index].Add(Select);
        }

        return Select;
    }

    private void OnApplicationQuit()
    {
        for(int i = 0; i < Prefabs.Length; i++)
        {
            EnemyParent enemyInfo;
            if (Prefabs[i].TryGetComponent<EnemyParent>(out enemyInfo))
            {
                enemyInfo.Init();
            }
        }
    }
}
