using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeThisActive : MonoBehaviour
{
    public Text buttontext;
    public GameObject actioncanvas;


    public void Update()
    {
        
    }

    public void ActionCanvas()
    {
        actioncanvas.SetActive(true);
        CloseCanvas();
    }

    public void CloseCanvas()
    {
        gameObject.SetActive(false);

       
    }
}