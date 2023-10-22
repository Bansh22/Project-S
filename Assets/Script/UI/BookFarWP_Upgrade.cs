using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookFarWP_Upgrade : MonoBehaviour
{
    //캐릭터변경
 
    public Sprite[] WP_Controller;
    private Image mySR;
    ConfigReader reader;
    int modelIndex;
    // Start is called before the first frame update
    public void Awake()
    {
        mySR = GetComponent<Image>();
        reader = new ConfigReader("Player");
        modelIndex = reader.Search<int>("Model");
        mySR.sprite = WP_Controller[modelIndex];
    }
 
}
