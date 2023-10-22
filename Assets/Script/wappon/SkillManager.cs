using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject[] SkillList;
    

    // Start is called before the first frame update
    void Start()
    {
        ConfigReader reader = new ConfigReader("Player");
        int skillNum=reader.Search<int>("Model");
        GameObject skill=Instantiate(SkillList[skillNum], GameManager.instance.player.transform);
        skill.transform.SetParent(null);
    }
}
