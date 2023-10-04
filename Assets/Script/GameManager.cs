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
        ConfigReader configreaders = new ConfigReader();
        configreaders.Initialize(configreaders.GetfilePath());
        configreaders.MakeDiction("Sap Wappon");

        object rowdata = configreaders.GetDictionaryValue("damage");
        Debug.Log(rowdata.ToString());

        instance = this;
        

    }
}

//������ �Ű������� �������� ��ųʸ��� ���� ��� ���� 
