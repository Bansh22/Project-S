using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnmouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttontext;

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (buttontext != null)
        {
            Text tx = buttontext.GetComponent<Text>();
            tx.color = new Color(0.83f, 0.71f, 0.26f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttontext != null)
        {
            Text tx = buttontext.GetComponent<Text>();
            tx.color = new Color(0.83f, 0.71f, 0.62f);
        }
    }
}