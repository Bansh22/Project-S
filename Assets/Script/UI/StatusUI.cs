using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    public GameObject status;
    public void OnStatus()
    {
        Time.timeScale = 0f;
        status.SetActive(true);
    }
}
