using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp,Level,Kill,Time,Health}
    public InfoType type;

    Text myText;
    Slider mySlilder;

    private void Awake()
    {
        mySlilder = GetComponent<Slider>();
        myText = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float subject=1000;
                mySlilder.value=GameManager.instance.catchEnemy/subject;
                break;
            case InfoType.Level:
                //Text에 들어갈 문자 
                //Format의 작성방식 ("형태", 변수) {0:F0}> 0번째 변수, F0 0개의 소수점
                myText.text = string.Format("LV.{0:F0}",GameManager.instance.speed);
                break;
            case InfoType.Kill:
                //Text에 들어갈 문자 
                //Format의 작성방식 ("형태", 변수) {0:F0}> 0번째 변수, F0 0개의 소수점
                myText.text = string.Format("{0:F0}", GameManager.instance.catchEnemy);
                break;
            case InfoType.Time:
                break;
            case InfoType.Health:
                break;
        }
    }
}
