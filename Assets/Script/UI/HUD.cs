using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp,Level,Kill,Time,Health}
    public InfoType type;

    RectTransform rect;
    Text myText;
    Slider mySlilder;

    float height;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        mySlilder = GetComponent<Slider>();
        myText = GetComponent<Text>();

        height = rect.sizeDelta.y;
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
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                FollowUI parentUI= gameObject.GetComponentInParent<FollowUI>();
                switch (parentUI.target.tag)
                {
                    case "Player":
                        Player player = parentUI.target.GetComponentInParent<Player>(); ;
                        mySlilder.value = GameManager.instance.player.hp/ GameManager.instance.player.maxHp;
                        break;
                    case "Enemy":
                        EnemyParent enemy= parentUI.target.GetComponentInParent<EnemyParent>();

                        if (!enemy.getLive())
                        {
                            FollowUI follow = gameObject.GetComponentInParent<FollowUI>();
                            follow.destroythis();
                            return;
                        }
                        else
                        {
                            mySlilder.value = enemy.getHp() / enemy.getMaxHp();
                        }
                        break;
                }
                break;
        }
    }
}
