using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI_town : MonoBehaviour

   
{
    [SerializeField]
    private GameObject Panel;
   

    // Start is called before the first frame update

   
    // Update is called once per frame
    
    
    private void CloseMenu()
    {

        //GameManager.ispause = false;
        gameObject.SetActive(false);
       
    }


    public void ClickContinue()
    {
       
        CloseMenu();
    }
    
    public void ClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        //에러 대비용 0f 코드 
        Time.timeScale = 0f;
    }
}
