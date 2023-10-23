using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Level,Kill,Time,Health,Result,Coin, CoinSlider,CatchCoin,SkillCool }
    public InfoType type;
    public Text Hptext;
    bool finshTrigger = false;
    bool coinTrigger = false;
    bool coinSliderTrigger = false;

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
                //수정 필요!
                myText.text = string.Format("Wave.{0:F0}", GameManager.instance.Level2+1);
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
                    int currentHp = Mathf.RoundToInt(player.getHp());
                    int maxHp = Mathf.RoundToInt(player.getMaxHp());
                    Hptext.text = currentHp.ToString() + " /  " + maxHp.ToString();
                    return;
                }
                switch (parentUI.target.tag)
                {
                    case "Enemy":
                        EnemyParent enemy= parentUI.target.GetComponentInParent<EnemyParent>();
                        if (enemy == null)
                        {
                            FollowUI follow = gameObject.GetComponentInParent<FollowUI>();
                            follow.destroythis();
                           
                            return;
                        }
                        bool live = enemy.IsLive;
                        if (!live)
                        {
                            FollowUI follow = gameObject.GetComponentInParent<FollowUI>();
                            follow.destroythis();
                           
                            return;
                        }
                        else
                        {
                            
                            mySlilder.value = enemy.Hp / enemy.MaxHp;
                           
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
                            int currentHp = Mathf.RoundToInt(player.getHp());
                            int maxHp = Mathf.RoundToInt(player.getMaxHp());
                            Hptext.text = currentHp.ToString() + " /  " + maxHp.ToString();
                        }
                        break;
                }
                break;
            case InfoType.Coin:
                if (coinTrigger && SceneManager.GetActiveScene().name!="Town")
                    return;
                coinTrigger = true;
                ConfigReader reader = new ConfigReader("Player");
                int coin = reader.Search<int>("gold");
                if (coin >= 999999)
                {
                    coin = 999999;
                }
                myText.text = coin + "$";
                break;
            case InfoType.CoinSlider:
                if (coinSliderTrigger)
                    return;
                coinSliderTrigger = true;
                ConfigReader reader1 = new ConfigReader("Player");
                float coin1 = reader1.Search<float>("gold");
                if (coin1 >= 999999)
                {
                    coin1 = 999999;
                }
                float num =0;
                while (coin1 >=1)
                {
                    coin1 =coin1/ 10;
                    num=num+1;
                }
                mySlilder.value = (6f - num) / 6f;
                break;
            case InfoType.CatchCoin:
                ConfigReader reader2 = new ConfigReader("Player");
                float coin2 = reader2.Search<float>("gold");
                if (finshTrigger)
                    break;
                finshTrigger = true;
                reader2.UpdateData("gold", (GameManager.instance.catchEnemy+coin2).ToString());
                myText.text = string.Format("+{0:F0}$", GameManager.instance.catchEnemy);
                break;
            case InfoType.SkillCool:
                if (GameManager.instance.coolTime == 0)
                {
                    GameManager.instance.coolTime = 1;
                }
                mySlilder.value = GameManager.instance.coolTimer / GameManager.instance.coolTime;
                break;
        }
    }
}
