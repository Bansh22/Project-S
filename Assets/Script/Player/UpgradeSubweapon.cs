using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UpgradeSubweapon : MonoBehaviour
{
    public GameObject activecan;
    public Text activecantext;
    public Text Damagetexts;
    public Text cooltexts;
    public Text counttexts;
    private ConfigReader readerplayer;
    private ConfigReader readerSapWappon;
    private ConfigReader readerShootingWappon;
    private int shootdamage;
    private float shootspeed;
    private int shootcount;
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
        model = readerplayer.Search<int>("Model");
        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootdamage = readerShootingWappon.Search<int>("damage" + model.ToString());
        Damagetexts.text = "Damage : " + shootdamage.ToString() + " / 70 ";

    
        shootspeed = readerShootingWappon.Search<float>("speed" + model.ToString());
        cooltexts.text = "Col : " + shootspeed.ToString() + " / 0.3 ";

        shootcount = readerShootingWappon.Search<int>("Count" + model.ToString());
        counttexts.text = "Count : " + shootcount.ToString() + " / 7 ";
    }
    public void SubDamageupgrade()
    {
        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootdamage = readerShootingWappon.Search<int>("damage" + model.ToString());

        if (shootdamage < 70)
        {
            if (paygold(2000))
            {
                float temp = shootdamage + 10;
                if (temp >= 70)
                {
                    temp = 70;
                }
                string stringtemp = temp.ToString();
                
                readerShootingWappon = new ConfigReader("Shooting Wappon");
                readerShootingWappon.UpdateData("damage" + model.ToString(), stringtemp);
                openconfirm();
                Damagetexts.text = "Damage : " + stringtemp + " / 70 ";
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
    public void subcoolup()
    {
        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootspeed = readerShootingWappon.Search<float>("speed" + model.ToString());
        if (shootspeed > 0.3)
        {
            if (paygold(4000))
            {
                float temp = shootspeed - 0.1f;
                if (temp <= 0.3f)
                {
                    temp =0.3f;
                }
                string stringtemp = temp.ToString("F1");

                readerShootingWappon = new ConfigReader("Shooting Wappon");
                readerShootingWappon.UpdateData("speed" + model.ToString(), stringtemp);
                openconfirm();
                cooltexts.text = "Col : " + stringtemp + " / 0.3 ";
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
    public void subcountup()
    {
        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootcount = readerShootingWappon.Search<int>("Count" + model.ToString());
        if (shootcount < 7)
        {
            if (paygold(4000))
            {
                float temp = shootcount + 1;
                if (temp >= 7)
                {
                    temp = 7;
                }
                string stringtemp = temp.ToString();
                readerShootingWappon = new ConfigReader("Shooting Wappon");
                readerShootingWappon.UpdateData("Count" + model.ToString(), stringtemp);
                openconfirm();
                counttexts.text = "Count : " + stringtemp + " / 7 ";
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
       
        if (gold < goldval)
        {
            return false;
        }
        int temp = gold - goldval;

        string stringtemp = temp.ToString();
        readerplayer.UpdateData("gold", stringtemp);

        return true;
    }
}
