using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_EOnOff : MonoBehaviour
{
    public GameObject EOn;
    public GameObject EOff;
   
    bool isEOn = true; // 초기 상태 설정

    public float toggleInterval = 1.0f; // 온/오프 간격 (예: 1초)

    private float timer;

    void Start()
    {
       
        timer = 0f;
    }

    void Update()
    {
        // 일정 시간이 경과하면 상태를 토글합니다.
        timer += Time.deltaTime;
        if (timer >= toggleInterval)
        {
            isEOn = !isEOn; // 상태 토글
            EOn.SetActive(isEOn);
            EOff.SetActive(!isEOn);
            timer = 0f; // 타이머 초기화
        }
    }
}