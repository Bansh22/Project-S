using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeThistotu : MonoBehaviour
{
    public Text buttontext;
    public GameObject actioncanvas;


    public void Update()
    {
        if (Input.anyKeyDown)
        {
            CloseCanvas();
        }
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
