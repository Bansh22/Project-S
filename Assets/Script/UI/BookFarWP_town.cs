using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookFarWP_town : MonoBehaviour
{
    //캐릭터변경
    private ConfigReader readerShootingWappon;
    public Sprite[] WP_Controller;
    private Image mySR;
    public Text WPLevel;
    public Text WPDamage;
    private float shootdamage;
    private float shootspeed;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<Image>();
        ConfigReader reader = new ConfigReader("Player");
        int modelIndex = reader.Search<int>("Model");
        mySR.sprite = WP_Controller[modelIndex];
    }
    private void Update()
    {
        readerShootingWappon = new ConfigReader("Shooting Wappon");
        shootspeed = readerShootingWappon.Search<float>("speed");
        shootdamage = readerShootingWappon.Search<float>("damage");
       
        shootspeed  = ((1 - shootspeed) * 10);
        string resultString = shootspeed.ToString("F0");
        WPLevel.text = "무기 레벨:" + resultString;
        WPDamage.text= "무기 데미지:" + shootdamage.ToString();
    }
}
