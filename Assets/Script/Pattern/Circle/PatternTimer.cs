using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTimer : MonoBehaviour
{
    public float timer;
    private float startTime;
    public GameObject pattern;
    // startTime is called before the first frame update
    void Start()
    {
        startTime = GameManager.instance.gameTime;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameTime - startTime>timer)
        {
            pattern.SetActive(true);
        } 
    }
}
