using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class buttononmoseoverevent : MonoBehaviour
{
    public Text text; // 버튼 위에 놓이는 텍스트 (예: 버튼 텍스트)
    public string onstring;
    public string outstring;


    // 마우스가 버튼에 진입할 때 호출됨
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 버튼 진입 시 수행할 동작 추가
        text.text = onstring; // 버튼 텍스트 변경 예시
    }

    // 마우스가 버튼을 빠져나갈 때 호출됨
    public void OnPointerExit(PointerEventData eventData)
    {
        // 버튼 빠져나갈 때 수행할 동작 추가
        text.text = outstring; // 버튼 텍스트를 원래대로 돌리는 예시
    }
}
