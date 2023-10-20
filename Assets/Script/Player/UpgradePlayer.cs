using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlayer : MonoBehaviour
{
    public GameObject activecan;
    private ConfigReader readerplayer;
    private ConfigReader readerSapWappon;
    private ConfigReader readerShootingWappon;
    private int shootdamage;
    private float shootspeed;
    private float Sapdamage;
    private int Sapcount;
    private int playerHP;
    private int playerSpeed;
    // Start is called before the first frame update
  

    public  void HPupgrade()
    {
        readerplayer = new ConfigReader("Player");
        playerHP = readerplayer.Search<int>("hp");
        Debug.Log(playerHP);
        if (playerHP < 401)
        {
            float temp = playerHP + 10;
        string stringtemp = temp.ToString();
        readerplayer.UpdateData("hp", stringtemp);
        }
        openconfirm();
    } 
    public void playerspeedup()
    {
        readerplayer = new ConfigReader("Player");
        playerSpeed = readerplayer.Search<int>("speed");
        if (playerSpeed < 6)
        {
            float temp = playerSpeed + 1;
            string stringtemp = temp.ToString();
            readerplayer.UpdateData("speed", stringtemp);
        }
        openconfirm();
    }
    public void sapatkup()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        Sapdamage = readerSapWappon.Search<float>("damage");
        Debug.Log(Sapdamage);
        if (Sapdamage < 70)
        {
            float temp = Sapdamage + 5;
            string stringtemp = temp.ToString();
            readerSapWappon.UpdateData("damage", stringtemp);
        }
        openconfirm();
    }
    public void sapcountup()
    {
        readerSapWappon = new ConfigReader("Sap Wappon");
        Sapcount = readerSapWappon.Search<int>("Count");
        if (Sapcount < 6)
        {
            float temp = Sapcount + 1;
            string stringtemp = temp.ToString();
            readerSapWappon.UpdateData("Count", stringtemp);
        }
        openconfirm();
    }
    public void shootspeedup()
    {

        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootspeed = readerShootingWappon.Search<float>("speed");
        if (shootspeed >0.6)
        {
            float temp = shootspeed - 0.1f;
            string stringtemp = temp.ToString();
            readerShootingWappon.UpdateData("speed", stringtemp);

        }
        openconfirm();
    }
    public void programmermode()
    {
        readerplayer = new ConfigReader("Player");
        playerHP = readerplayer.Search<int>("hp");
      
            float temp = 9999f;
            string stringtemp = temp.ToString();
            readerplayer.UpdateData("hp", stringtemp);

        openconfirm();

    }

    public void openconfirm()
    {
        activecan.SetActive(true);
    }
}
