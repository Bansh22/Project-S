using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookNearWP : MonoBehaviour
{
    //캐릭터변경
    public Sprite[] WP_Controller;
    private Image mySR;
    public Text WPLevel;
    public Text WPDamage;
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
        WPLevel.text = "무기 레벨:"+(nearing_Wappon_Manager.GetCount(0)-2).ToString();
        WPDamage.text = "무기 데미지:" + nearing_Wappon_Manager.GetCount(1).ToString();
    }
}
