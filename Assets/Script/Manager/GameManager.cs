using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

   [Header("#Manager")]
    public Pool_Manager_Script PolManage;
    public Wappon_Pool_Manager_Script WaPolManage;
    public AudioManageer AudioManager;

    [Header("#PlayerInfo")]
    public Player player;
    public float speed=5;

    [HideInInspector]
    public float catchEnemy=0;

    private void Awake()
    {
        instance = this;
    }
}

//가져올 매개변수를 바탕으로 딕셔너리로 값을 모두 들고옴 
