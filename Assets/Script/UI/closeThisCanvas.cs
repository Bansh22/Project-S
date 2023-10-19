using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeThisCanvas : MonoBehaviour
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

        Text tx = buttontext.GetComponent<Text>();
        tx.color = new Color(0.83f, 0.71f, 0.62f);

    }
}
