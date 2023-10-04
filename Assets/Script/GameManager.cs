using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public float speed = 5;
    private void Awake()
    {
        instance = this;
    }
}
