using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour
{
    public void GoToVillage()
    {
        GameManager.instance.gameTime = 0f;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Town");
    }
    public void GoToBattle()
    {
        GameManager.instance.gameTime = 0f;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("BattleField");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
