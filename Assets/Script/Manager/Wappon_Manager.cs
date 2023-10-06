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
        Debug.Log("��ġ ���ư�!");
        for (int index = 0; index < Count; index++)
        {
            Debug.Log("for�� �ȿ� ����!!");
            Transform BulletTrans = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
            BulletTrans.parent = transform;
            BulletTrans.GetComponent<SapWappon>().Init(Damage, -1);
            Debug.Log("������!");
        }
    }
    public float GetDamage()
    {
        return Damage;
    }
}
