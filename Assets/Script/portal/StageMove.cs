using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMove : MonoBehaviour
{
    // Start is called before the first frame update
    public void stage1gogo()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void stage2gogo()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void stage3gogo()
    {
        SceneManager.LoadScene("Stage3");
    }
}
