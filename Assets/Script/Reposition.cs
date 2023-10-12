using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;
    ConfigReader reader;
    float box_area;
    float angle;
    //몹 스폰 범위 각도
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
        //if playerDir 이게 0,0 이면 저장된 playerDir(가상)을 사용한다 

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * (transform.position.x < collision.transform.position.x ? 1 : -1) * 40);
                    float difY = Mathf.Abs(playerPos.y - myPos.y);
                    if (difY >= 20)
                    {
                        transform.Translate(Vector3.up * (transform.position.y < player.transform.position.y ? 1 : -1) * 40);
                    }
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * (transform.position.y < collision.transform.position.y ? 1 : -1) * 40);
                    float difX = Mathf.Abs(playerPos.x - myPos.x);
                    if (difX >= 20)
                    {
                        transform.Translate(Vector3.right * (transform.position.x < player.transform.position.x ? 1 : -1) * 40);
                    }
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 unitPly = playerDir.normalized;
                    //대각선에 의해 크기가 1보다 커지는 것을 대비
                    float radian = Random.Range(-angle, angle) * Mathf.PI / 180.0f;
                    //각도를 라디안으로 변환
                    Vector3 spawnRadian = new Vector3(unitPly.x * Mathf.Cos(radian) - unitPly.y * Mathf.Sin(radian), unitPly.x * Mathf.Sin(radian) + unitPly.y * Mathf.Cos(radian));
                    //유저 이동하는 방향(단위벡터)에서 램덤 각도로 회전 
                    transform.position = playerPos + 10 * spawnRadian;
                    //유저 기준으로 반지름 10인 원 테두리에서 스폰(설정된 각도에서만)
                }
                break;
        }
    }
}
