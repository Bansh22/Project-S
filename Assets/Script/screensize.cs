using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screensize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int width = 1920;
        int height = 1080;
        Screen.SetResolution(width,height,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
