using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // 액션 사용 라이브러리 
public class Shooting_Wappon_Manager : MonoBehaviour
{
    private ConfigReader reader;
    //private int Id;
    private int PrefubId;
    private float Damage;
    [HideInInspector] public int Count;
    private float Speed;
    Transform scrptTrsfrom;
    private GameObject[] arraygameobj;
    public static Action CountTarget; //액션 선언 
    public static Action DeleteWeapon; //액션 선언 
    public static Func<int,int> GetCount; //액션 선언
                                          //
    private float timer;
    private Player pler;
   
    private void Start()
    { 
        // = GetComponent<Transform>();
        reader = new ConfigReader("Shooting Wappon");
        Damage = reader.Search<float>("damage");
        Speed = reader.Search<float>("speed");
        Count = reader.Search<int>("Count");
        PrefubId = reader.Search<int>("PrefubId");
        pler = GetComponentInParent<Player>();


    }
    private void Awake()
    {
       //액션 실행시 작동하는거 
        GetCount=(int a)=> {
            return getCount();
        };
        DeleteWeapon = () => {
            DestoryWeapon();
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer > Speed)
        {
            timer = 0;
            FireShhooting();
        }


    }


    void Batch()
    {
        if (getCount() < 8)
        {
            Transform BulletTrans = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
            BulletTrans.parent = transform;
            
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
            bullset[index].position=bullset[index].position+ bullset[index].up * 0.5f * (Count) ;

          

        }
    }
    public void DestoryWeapon()
    {
       foreach(GameObject child in arraygameobj)
        {
            Destroy(child);
        }
        
    }

    public void FireShhooting()
    {
        Debug.Log("작동");
        if (!pler.mobscan.nearestTarget)
        {
            return;
        }
     
        Transform bullset = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
        bullset.position = transform.position;
        Debug.Log("발사!");
    }

    public int getCount()
    {
        return Count;
    }

    public float GetDamage()
    {
        return Damage;
    }
}
