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

        // 360���� �������� ������ ����Ʈ ��ġ
        for (int i = 0; i < SpawnerPoint.Length; i++)
        {
            float angle = (float)i / SpawnerPoint.Length * 360.0f;
            float radians = angle * Mathf.PI / 180.0f;

            // ������ 10�� �� ������ �� ��ġ
            float x = parentPosition.x + 10 * Mathf.Cos(radians);
            float y = parentPosition.y + 10 * Mathf.Sin(radians);
            SpawnerPoint[i].position = new Vector3(x, y, parentPosition.z);
        }
    }



    void Update() // �ð��� ���� ������ 
    {
        timer += Time.deltaTime;

        if(timer > 0.2f) //0.2�ʿ� 1��! 1���� ����!
        {
            SpawnMod(1);
            timer = 0f;
        }
    }

    void SpawnMod(int number) //���� ������ �ڵ� (number�� �� ������ �־ ���!)
    {
       GameObject enemy =   GameManager.instance.PolManage.GetPoolsPrefabs(number);
        enemy.transform.position = SpawnerPoint[Random.Range(1, SpawnerPoint.Length)].position;
    }
}
