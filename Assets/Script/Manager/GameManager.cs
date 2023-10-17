using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]

public class GameManager : MonoBehaviour
{


    public static GameManager instance;

   [Header("#Manager")]
    public Pool_Manager_Script PolManage;
    public Wappon_Pool_Manager_Script WaPolManage;
    public AudioManageer AudioManager;
    public static bool ispause = false;
    public UIManager uiManger;
    public Drop_Manage DropManage;

    [Header("#PlayerInfo")]
    public Player player;

    [HideInInspector] public float catchEnemy=0;
    [HideInInspector] public float maxGameTime;
    [HideInInspector] public float gameTime=0;
    private ConfigReader reader;


    private void Awake()
    {
        reader = new ConfigReader("Timer");
        maxGameTime = reader.Search<float>("maxTime");
        instance = this;
    }
    private void Start()
    {
        Scene scene= SceneManager.GetActiveScene();
        if (scene.name=="Town")
        {
            AudioManageer.instance.PlayBgm(AudioManageer.Bgm.Village);
        }
        else
        {
            AudioManageer.instance.PlayBgm(AudioManageer.Bgm.Battle1);
        }
    }

    private void FixedUpdate()
    {
        gameTime += Time.fixedDeltaTime;
    }
}

//가져올 매개변수를 바탕으로 딕셔너리로 값을 모두 들고옴 
