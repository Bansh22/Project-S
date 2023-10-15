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
    private float movespeed;
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
        movespeed = reader.Search<float>("movespeed");
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


   
    public void DestoryWeapon()
    {
       foreach(GameObject child in arraygameobj)
        {
            Destroy(child);
        }
        
    }

    public void FireShhooting()
    {
      
        if (!pler.mobscan.nearestTarget)
        {
            return;
        }

        Vector3 targetpos = pler.mobscan.nearestTarget.position;
        Vector3 dir = targetpos - transform.position;
        dir = dir.normalized;

        Transform bullset = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
        
        bullset.position = transform.position;
        bullset.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullset.GetComponent<Shooting_Wappon>().Init(Damage ,dir , movespeed);
      
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
