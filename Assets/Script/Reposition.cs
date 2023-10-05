using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;
    ConfigReader reader;
    float angle;
    //�� ���� ���� ����
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        reader = new ConfigReader("Reposition");
        angle = reader.Search<float>("angle");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        Player player = GameManager.instance.player;
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        Vector3 playerDir = player.inputVec;
        //if playerDir �̰� 0,0 �̸� ����� playerDir(����)�� ����Ѵ� 


        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if ( diffX > diffY)
                {
                    transform.Translate(Vector3.right * (transform.position.x < collision.transform.position.x ? 1:-1) * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * (transform.position.y < collision.transform.position.y ? 1 : -1) * 40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 unitPly = playerDir.normalized;
                    //�밢���� ���� ũ�Ⱑ 1���� Ŀ���� ���� ���
                    float radian = Random.Range(-angle, angle) * Mathf.PI / 180.0f;
                    //������ �������� ��ȯ
                    Vector3 spawnRadian = new Vector3(unitPly.x * Mathf.Cos(radian) - unitPly.y * Mathf.Sin(radian), unitPly.x * Mathf.Sin(radian) + unitPly.y * Mathf.Cos(radian));
                    //���� �̵��ϴ� ����(��������)���� ���� ������ ȸ�� 
                    transform.position = playerPos + 10 * spawnRadian;
                    //���� �������� ������ 10�� �� �׵θ����� ����(������ ����������)
                }
                break;
        }

    }
}
