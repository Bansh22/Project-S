using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeThisActive : MonoBehaviour
{
 

    public void Update()
    {
        
    }

    public void ActionCanvas()
    {
       
        CloseCanvas();
    }

    public void CloseCanvas()
    {
        gameObject.SetActive(false);

       
    }
}
