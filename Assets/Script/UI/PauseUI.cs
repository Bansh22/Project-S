using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour

   
{
    [SerializeField]
    private GameObject ThisUI;
   

    // Start is called before the first frame update

    void Start()
    {
        ThisUI.SetActive(false);
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
        ThisUI.SetActive(true);
        Time.timeScale = 0f;
    }
    private void CloseMenu()
    {
        
        //GameManager.ispause = false;
        ThisUI.SetActive(false);
        Time.timeScale = 1f;
    }


    public void ClickContinue()
    {
       
        CloseMenu();
    }
    public void ClicjgotoHome()
    {

    }
    public void ClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        //에러 대비용 0f 코드 
        Time.timeScale = 0f;
    }
}
