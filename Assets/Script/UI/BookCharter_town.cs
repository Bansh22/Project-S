using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCharter_town : MonoBehaviour
{
    //캐릭터변경
    private ConfigReader readerplayer;
    public Sprite[] CR_Controller;
    private Image mySR;
    public Text HP;
    public Text SPeed;
    private int model;

    private int playerHP;
    private int playerSpeed;
    // Start is called before the first frame update
    void Start()
    {

        mySR = GetComponent<Image>();
        ConfigReader reader = new ConfigReader("Player");
        model = reader.Search<int>("model");

        int modelIndex = reader.Search<int>("Model");
        mySR.sprite = CR_Controller[modelIndex];
    }
    private void Update()
    {
 
        readerplayer = new ConfigReader("Player");
        playerHP = readerplayer.Search<int>("hp" + model.ToString());
        playerSpeed = readerplayer.Search<int>("speed" + model.ToString());
        HP.text = "체력:" + playerHP.ToString();
        SPeed.text = "이동 속도:" + playerSpeed.ToString();
    }
}
