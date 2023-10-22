using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookCharter : MonoBehaviour
{
    //캐릭터변경
    public Sprite[] CR_Controller;
    private Image mySR;
    public Text HP;
    public Text SPeed;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<Image>();
        ConfigReader reader = new ConfigReader("Player");
        int modelIndex = reader.Search<int>("Model");
        mySR.sprite = CR_Controller[modelIndex];
    }
    private void Update()
    {
        Player ply = GameManager.instance.player;
        HP.text = "체력:"+((int)ply.getHp()).ToString() + "/"+ ((int)ply.getMaxHp()).ToString();
        SPeed.text = "이동 속도:" + ((int)(ply.getSpeed()*100)).ToString();
    }
}
