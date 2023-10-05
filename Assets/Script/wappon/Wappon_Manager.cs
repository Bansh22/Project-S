using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappon_Manager : MonoBehaviour
{
    public int Id;
    public int PrefubId;
    public float Damage;
    public int Count;
    public float Speed;


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        switch(Id) {
            case 0:
                Speed = -150;
                Batch();


                break;

            default:
                break;
        }
    }

    internal void Batch()
    {
        for (int index = 0; index < Count; index++){
            //Transform bullect = GameManager.instrance.pool.(profabId).transform; 풀매니저 있어야함!
        }
    }
}
