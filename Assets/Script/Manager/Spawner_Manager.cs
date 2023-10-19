using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner_Manager : MonoBehaviour
{
    public Transform[] SpawnerPoint;
    float[] timers;
    int start = 0;
    int end = 2;
    int delta = 0;
    int mobTime = 1;

    // Update is called once per frame
    private void Awake()
    {
        
        SpawnerPoint = GetComponentsInChildren<Transform>();
        /*
        Vector3 parentPosition = transform.position;
      
        // 360도를 원형으로 나누어 포인트 배치
        for (int i = 0; i < SpawnerPoint.Length; i++)
        {
            float angle = (float)i / SpawnerPoint.Length * 360.0f;
            float radians = angle * Mathf.PI / 180.0f;

            // 반지름 10의 원 주위에 점 배치
            float x = parentPosition.x + 10 * Mathf.Cos(radians);
            float y = parentPosition.y + 10 * Mathf.Sin(radians);
            
            SpawnerPoint[i].position = new Vector3(x, y, parentPosition.z);
        }*/
    }
    private void Start()
    {
        timers = new float[GameManager.instance.PolManage.Prefabs.Length];
        for (int i = 0; i < timers.Length; i++)
        {
            timers[i] = 0f;
        }
        mobTime = GameManager.instance.mobLevel;
    }


    void FixedUpdate() // 시간에 따른 몹생성 
    {
        int mobLevel = (int)GameManager.instance.gameTime / mobTime;
        if (delta != mobLevel)
        {
            delta = mobLevel;
            if(timers.Length >= end + mobLevel + 2)
            {
                start = end;
                end = start + mobLevel + 2;
            }
        }
        for (int i = start; i < end; i++)
        {
            if (GameManager.instance.gameTime-timers[i] > GameManager.instance.PolManage.Prefabs[i].GetComponent<EnemyParent>().getRegen()) //0.2초에 1번! 1번몹 생성! 0.02보다 빨라지면 문제생김
            {
                SpawnMod(i);
                timers[i] = GameManager.instance.gameTime;
            }
        }
    }

    void SpawnMod(int number) //실제 몹생성 코드 (number에 값 여러개 넣어서 써라!)
    {
        Vector3 pos = SpawnerPoint[Random.Range(1, SpawnerPoint.Length)].position;
        
        GameObject enemy =   GameManager.instance.PolManage.GetPoolsPrefabs(number, pos);
        enemy.transform.position = pos;
        
    }
}
