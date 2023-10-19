using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour

   
{
    [SerializeField]
    private GameObject Panel;
   

    // Start is called before the first frame update

    void Start()
    {
        Panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            CallMenu();
           
        }
    }
    private void CallMenu()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void CloseMenu()
    {

        //GameManager.ispause = false;
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }


    public void ClickContinue()
    {
       
        CloseMenu();
    }
    public void ClicjgotoHome()
    {
        GameManager.instance.gameTime = 0f;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Town");
        GameManager.instance.player.transform.position = new Vector3(11.61f, -4.8f, 0);
    }
    public void ClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        //에러 대비용 0f 코드 
        Time.timeScale = 0f;
    }
}
