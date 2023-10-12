using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // 액션 사용 라이브러리 
public class Wappon_Manager : MonoBehaviour
{
    private ConfigReader reader;
    //private int Id;
    private int PrefubId;
    private float Damage;
    private int Count;
    private float Speed;
    Transform scrptTrsfrom;
    GameObject[] arraygameobj;
    public static Action CountTarget; //액션 선언 
    public static Action DeleteWeapon; //액션 선언 
    private void Start()
    { 
        // = GetComponent<Transform>();
        reader = new ConfigReader("Sap Wappon");
        Damage = reader.Search<float>("damage");
        Speed = reader.Search<float>("speed");
        Count = 0;
        PrefubId = reader.Search<int>("PrefubId");
        Init();

       
    }
    private void Awake()
    {
        CountTarget = () => { 
            CountUp();
        }; //액션 실행시 작동하는거 
        DeleteWeapon = () => {
            DestoryWeapon();
        };
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * Speed * Time.deltaTime);


    }
    public void Init()
    {
        Batch();
        Batch();
        Batch();
        SetPosition();
    }
    public void CountUp()
    {
        Batch(); 
        SetPosition();
    }

    void Batch()
    {
        if (Count < 8)
        {


            Transform BulletTrans = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
            BulletTrans.parent = transform;

            Count++;


            BulletTrans.GetComponent<SapWappon>().Init(Damage, -1);
        }
       
    }

    void SetPosition()
    {
        scrptTrsfrom = GetComponent<Transform>();
        Transform[] bullset = transform.gameObject.GetComponentsInChildren<Transform>();
        arraygameobj = new GameObject[bullset.Length - 1];
        for (int index = 1; index < bullset.Length; index++)
        {
            Vector3 rotVec = Vector3.forward * 360 * (index-1) / (bullset.Length-1);
            arraygameobj[index-1] = bullset[index].gameObject;
            
            bullset[index].rotation = scrptTrsfrom.rotation;
            bullset[index].position = scrptTrsfrom.position;
            bullset[index].Rotate(rotVec);
            bullset[index].position=bullset[index].position+ bullset[index].up * 0.5f * (Count-1) ;

          

        }
    }
    public void DestoryWeapon()
    {
       foreach(GameObject child in arraygameobj)
        {
            Destroy(child);
        }
        
    }
 

    public float GetDamage()
    {
        return Damage;
    }
}
