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
