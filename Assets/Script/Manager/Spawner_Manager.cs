using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Manager : MonoBehaviour
{
    public Transform[] SpawnerPoint;
    float timer;

    // Update is called once per frame
    private void Awake()
    {
        SpawnerPoint = GetComponentsInChildren<Transform>();
        
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
        }
    }



    void FixedUpdate() // 시간에 따른 몹생성 

    {
        timer += Time.deltaTime;

        if(timer > 0.2f) //0.2초에 1번! 1번몹 생성!
        {
            SpawnMod(Random.Range(0,GameManager.instance.PolManage.Prefabs.Length));
            timer = 0f;
        }
    }

    void SpawnMod(int number) //실제 몹생성 코드 (number에 값 여러개 넣어서 써라!)
    {
       GameObject enemy =   GameManager.instance.PolManage.GetPoolsPrefabs(number);
       enemy.transform.position = SpawnerPoint[Random.Range(1, SpawnerPoint.Length)].position;
        
    }
}
