using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinshButtonUI : MonoBehaviour
{
    bool checkEnding =false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.getLive())
        {
            gameObject.GetComponent<Text>().text = "Next";
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Stage3")
            {
                checkEnding = true;
            }
            if (checkEnding)
            {
                gameObject.GetComponent<Text>().text = "Ending";
            }
        }
    }
}
