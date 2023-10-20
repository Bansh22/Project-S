using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookNearWP_town : MonoBehaviour
{
    private ConfigReader readerSapWappon;
    //캐릭터변경
    public Sprite[] WP_Controller;
    private Image mySR;
    public Text WPLevel;
    public Text WPDamage;
    private float Sapdamage;
    private int Sapcount;
    public int modelIndex;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<Image>();
        ConfigReader reader = new ConfigReader("Player");
        modelIndex = reader.Search<int>("Model");
        mySR.sprite = WP_Controller[modelIndex];

    }
    private void Update()
    {
       
        readerSapWappon = new ConfigReader("Sap Wappon");
        Sapdamage = readerSapWappon.Search<float>("damage"+ modelIndex.ToString());
        Sapcount = readerSapWappon.Search<int>("Count" + modelIndex.ToString());
        WPLevel.text = "무기 레벨:"+ Sapcount.ToString();
        WPDamage.text = "무기 데미지:" + Sapdamage.ToString();
    }
}
