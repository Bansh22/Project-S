using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    public float speed=5;
    public Player player;


    private void Awake()
    {
      
        instance = this;
        

    }
}

//가져올 매개변수를 바탕으로 딕셔너리로 값을 모두 들고옴 
