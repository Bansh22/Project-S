using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;
    public Player plr;
    public Sprite spsp;
    private void Awake()
    {
        img = gameObject.GetComponent<Image>();
       
    }
    void Update()
    {
        spsp = plr.GetComponent<SpriteRenderer>().sprite;
        img.sprite = spsp;
    }
}
