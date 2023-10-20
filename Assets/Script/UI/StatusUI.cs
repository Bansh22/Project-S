using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    public GameObject status;
    public bool on=false;
    public void OnStatus()
    {
        if (!on)
        {
            Time.timeScale = 0f;
            status.SetActive(true);
            on = true;
        }
        else
        {
            Time.timeScale = 1f;
            status.SetActive(false);
            on = false;
        }
    }   
}
