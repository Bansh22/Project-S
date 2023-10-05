using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wappon_Manager : MonoBehaviour
{
    private ConfigReader reader;
    //private int Id;
    private int PrefubId;
    private float Damage;
    private int Count;
    private float Speed;

    private void Start()
    {
        reader = new ConfigReader("Sap Wappon");
        Damage = reader.Search<float>("damage");
        Speed = reader.Search<float>("speed");
        Count = reader.Search<int>("Count");
        PrefubId = reader.Search<int>("PrefubId");
        Init();

       
    }



    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Speed * Time.deltaTime);


    }
    public void Init()
    {
        Batch();
    }

    void Batch()
    {
        
        for (int index = 0; index < Count; index++)
        {
           
            Transform BulletTrans = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
            BulletTrans.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * index / Count;
            BulletTrans.Rotate(rotVec);
            BulletTrans.Translate(BulletTrans.up * 1.5f, Space.World);
            
            BulletTrans.GetComponent<SapWappon>().Init(Damage, -1);
           
        }
    }
    public float GetDamage()
    {
        return Damage;
    }
}
