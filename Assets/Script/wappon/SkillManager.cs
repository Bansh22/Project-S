using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    public GameObject[] SkillList;
    

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name=="Town"|| SceneManager.GetActiveScene().name == "Start")
        {

        }
        else
        {
            ConfigReader reader = new ConfigReader("Player");
            int skillNum=reader.Search<int>("Model");
            GameObject skill=Instantiate(SkillList[skillNum], GameManager.instance.player.transform);
            skill.transform.SetParent(null);
        }
    }
}
