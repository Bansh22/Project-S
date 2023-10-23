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
        if (GameManager.instance.player.getLive())
        {
            Scene scene = SceneManager.GetActiveScene();
            for(int i = 1; i < 3; i++)
            {
                if (scene.name == "Stage"+i.ToString())
                {
                    SceneManager.LoadSceneAsync("Stage"+(i+1).ToString());
                    break;
                }
            }
        }
        else
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(scene.name);
        }
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
