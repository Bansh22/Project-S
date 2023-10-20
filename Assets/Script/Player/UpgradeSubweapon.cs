using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UpgradeSubweapon : MonoBehaviour
{
    public GameObject activecan;
    public Text activecantext;
    public Text HPtexts;
    public Text playerspeedtexts;
    private ConfigReader readerplayer;
    private ConfigReader readerSapWappon;
    private ConfigReader readerShootingWappon;
    private int shootdamage;
    private float shootspeed;
    private float Sapdamage;
    private int Sapcount;
    private int model;
    private int playerHP;
    private int playerSpeed;
    private int gold;
    // Start is called before the first frame update

    public void Awake()
    {
        readerplayer = new ConfigReader("Player");
        model = readerplayer.Search<int>("model");
        playerHP = readerplayer.Search<int>("hp" + model.ToString());
        HPtexts.text = "HP : " + playerHP.ToString() + " / 400 ";

        readerplayer = new ConfigReader("Player");
        playerSpeed = readerplayer.Search<int>("speed" + model.ToString());
        playerspeedtexts.text = "Speed : " + playerSpeed.ToString() + " / 7 ";
    }
    public void HPupgrade()
    {
        readerplayer = new ConfigReader("Player");
        playerHP = readerplayer.Search<int>("hp" + model.ToString());

        if (playerHP < 391)
        {
            if (paygold(2000))
            {
                float temp = playerHP + 10;
                if (temp >= 400)
                {
                    temp = 400;
                }
                string stringtemp = temp.ToString();
                readerplayer.UpdateData("hp" + model.ToString(), stringtemp);
                openconfirm();
                HPtexts.text = "HP : " + stringtemp + " / 400 ";
            }
            else
            {
                goldless();
            }
        }
        else
        {
            maxopen();
        }

    }
    public void playerspeedup()
    {
        readerplayer = new ConfigReader("Player");
        playerSpeed = readerplayer.Search<int>("speed" + model.ToString());
        if (playerSpeed < 7)
        {
            if (paygold(1000))
            {
                float temp = playerSpeed + 1;
                if (temp >= 7)
                {
                    temp = 7;
                }
                string stringtemp = temp.ToString();
                readerplayer.UpdateData("speed" + model.ToString(), stringtemp);
                openconfirm();
                playerspeedtexts.text = "Speed : " + stringtemp + " / 7 ";
            }
            else
            {
                goldless();
            }
        }
        else
        {
            maxopen();
        }
    }


    public void programmermode()
    {
        if (playerHP < 5000)
        {
            readerplayer = new ConfigReader("Player");
            playerHP = readerplayer.Search<int>("hp" + model.ToString());

            float temp = 9999f;
            string stringtemp = temp.ToString();
            readerplayer.UpdateData("hp" + model.ToString(), stringtemp);
            HPtexts.text = "HP : " + stringtemp + " / " + stringtemp + " ";
            openconfirm();
        }
        else
        {
            programopen();
        }

    }
    public void openconfirm()
    {
        activecan.SetActive(true);
        activecantext.text = "업그레이드 되었습니다!";
    }
    public void maxopen()
    {
        activecan.SetActive(true);
        activecantext.text = "업그레이드 최대치입니다!";
    }
    public void goldless()
    {
        activecan.SetActive(true);
        activecantext.text = "골드가 모자릅니다!!";
    }
    public void programopen()
    {
        activecan.SetActive(true);
        activecantext.text = "이미 프로그래머 모드입니다!";
    }
    public bool paygold(int goldval)
    {
        readerplayer = new ConfigReader("Player");
        gold = readerplayer.Search<int>("gold");
        int temp = gold - goldval;
        if (temp < 0)
        {
            return false;
        }
        string stringtemp = temp.ToString();
        readerplayer.UpdateData("gold", stringtemp);

        return true;
    }
}
