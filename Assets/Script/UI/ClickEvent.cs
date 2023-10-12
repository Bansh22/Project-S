using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour
{
    public void GoToVillage()
    {
        SceneManager.LoadScene("Town");
        Time.timeScale = 1f;
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("BattleField");
        Time.timeScale = 1f;
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
