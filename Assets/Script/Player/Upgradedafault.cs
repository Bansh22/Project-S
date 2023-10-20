using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Upgradedafault : MonoBehaviour
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
    // Start is called before the first frame update

    public void Awake()
    {
        readerplayer = new ConfigReader("Player");
        model = readerplayer.Search<int>("Model");
        playerHP = readerplayer.Search<int>("hp"+ model.ToString());
        HPtexts.text = "HP : " + playerHP.ToString() + " / 400 ";

        readerplayer = new ConfigReader("Player");
        playerSpeed = readerplayer.Search<int>("speed" + model.ToString() + model.ToString());
        playerspeedtexts.text = "Speed : " + playerSpeed.ToString() + " / 7 ";
    }
    public  void HPupgrade()
    {
        readerplayer = new ConfigReader("Player");
        playerHP = readerplayer.Search<int>("hp" + model.ToString());
      
        if (playerHP < 391)
        {
            
            float temp = playerHP + 10;
            if(temp >= 400)
            {
                temp = 400;
            }
            string stringtemp = temp.ToString();
            readerplayer.UpdateData("hp" + model.ToString(), stringtemp);
            openconfirm();
            HPtexts.text = "HP : " + stringtemp + " / 400 " ;
            paygold();
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
            
            float temp = playerSpeed + 1;
            if (temp >= 7)
            {
                temp = 7;
            }
            string stringtemp = temp.ToString();
            readerplayer.UpdateData("speed" + model.ToString(), stringtemp);
            openconfirm();
            playerspeedtexts.text = "Speed : " + stringtemp + " / 7 ";
            paygold();
        }
        else
        {
            maxopen();
        }
    }
   
    public void sapatkup()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        Sapdamage = readerSapWappon.Search<float>("damage" + model.ToString());
        Debug.Log(Sapdamage);
        if (Sapdamage < 70)
        {
            float temp = Sapdamage + 5;
            string stringtemp = temp.ToString();
            readerSapWappon.UpdateData("damage" + model.ToString(), stringtemp);
        }
        openconfirm();
    }
    public void sapcountup()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        Sapcount = readerSapWappon.Search<int>("Count"+model.ToString());
        if (Sapcount < 6)
        {
            float temp = Sapcount + 1;
            string stringtemp = temp.ToString();
            readerSapWappon.UpdateData("Count"+model.ToString(), stringtemp);
        }
        openconfirm();
    }
    public void shootspeedup()
    {

        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootspeed = readerShootingWappon.Search<float>("speed" + model.ToString());
        if (shootspeed >0.6)
        {
            float temp = shootspeed - 0.1f;
            string stringtemp = temp.ToString();
            readerShootingWappon.UpdateData("speed" + model.ToString(), stringtemp);

        }
        openconfirm();
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
    public void programopen()
    {
        activecan.SetActive(true);
        activecantext.text = "이미 프로그래머 모드입니다!";
    }
    public void paygold()
    {

    }
}
