using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour
{
    public void GoToVillage()
    {
        SceneManager.LoadScene("Town");
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("cesdea");
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
