using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    public Pool_Manager_Script PolManage;
    public float speed=5;
    public Player player;


    private void Awake()
    {
        
        instance = this;
    }
}

//������ �Ű������� �������� ��ųʸ��� ���� ��� ���� 
