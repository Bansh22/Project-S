using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Upgrademainweapon : MonoBehaviour
{
    public GameObject activecan;
    public Text activecantext;
    public Text Damagetexts;
    
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
        readerSapWappon = new ConfigReader("Sap Wappon");
        shootdamage = readerSapWappon.Search<int>("damage" + model.ToString());
        Damagetexts.text = "Damage : " + shootdamage.ToString() + " / 70 ";


       

        shootcount = readerSapWappon.Search<int>("Count" + model.ToString());
        counttexts.text = "Count : " + shootcount.ToString() + " / 6 ";
    }
    public void mainDamageupgrade()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        shootdamage = readerSapWappon.Search<int>("damage" + model.ToString());

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

                readerSapWappon = new ConfigReader("Sap Wappon");
                readerSapWappon.UpdateData("damage" + model.ToString(), stringtemp);
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
    
    public void maincountup()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        shootcount = readerSapWappon.Search<int>("Count" + model.ToString());
        if (shootcount < 6)
        {
            if (paygold(2000))
            {
                float temp = shootcount + 1;
                if (temp >= 6)
                {
                    temp = 6;
                }
                string stringtemp = temp.ToString();
                readerSapWappon = new ConfigReader("Sap Wappon");
                readerSapWappon.UpdateData("Count" + model.ToString(), stringtemp);
                openconfirm();
                counttexts.text = "Count : " + stringtemp + " / 6 ";
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
