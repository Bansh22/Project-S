using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Level,Kill,Time,Health,Result}
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
           case InfoType.Level:
                //Text에 들어갈 문자 
                //Format의 작성방식 ("형태", 변수) {0:F0}> 0번째 변수, F0 0개의 소수점
                myText.text = string.Format("LV.{0:F0}",GameManager.instance.speed);
                break;
            case InfoType.Result:
                //Text에 들어갈 문자 
                if (GameManager.instance.player.getLive())
                {
                    myText.text = "Live";
                }
                else
                {
                    myText.text = "Dead";
                }
                break;
            case InfoType.Kill:
                //Text에 들어갈 문자 
                //Format의 작성방식 ("형태", 변수) {0:F0}> 0번째 변수, F0 0개의 소수점
                myText.text = string.Format("{0:F0}", GameManager.instance.catchEnemy);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                if (remainTime < 0)
                    remainTime = 0;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                FollowUI parentUI= gameObject.GetComponentInParent<FollowUI>();
                if (!parentUI)
                {
                    Player player = GameManager.instance.player;
                    mySlilder.value = player.getHp() / player.getMaxHp();
                    return;
                }
                switch (parentUI.target.tag)
                {
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
                    case "Player":
                        Player player = parentUI.target.GetComponentInParent<Player>(); ;
                        if (!player.getLive())
                        {
                            FollowUI follow = gameObject.GetComponentInParent<FollowUI>();
                            follow.destroythis();
                            return;
                        }
                        else
                        {
                            mySlilder.value = player.getHp() / player.getMaxHp();
                        }
                        break;
                }
                break;
        }
    }
}
