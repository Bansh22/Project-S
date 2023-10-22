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
    private int targetLimit;
    Transform scrptTrsfrom;
    private GameObject[] arraygameobj;
    public static Action CountTarget; //액션 선언 
    public static Action DeleteWeapon; //액션 선언 
    public static Func<int,int> GetCount; //액션 선언
    private int Model;
                                          //
    private float timer;
    private Player pler;
    public float fireDelay = 0.1f;
    public int index;

    private bool stop = false;
    private void Start()
    {
        index = 0;
        // = GetComponent<Transform>();

        reader = new ConfigReader("Player");
        Model = reader.Search<int>("Model");
        reader = new ConfigReader("Shooting Wappon");
        Damage = reader.Search<float>("damage"+Model.ToString());
        Speed = reader.Search<float>("speed" + Model.ToString());
        Count = reader.Search<int>("Count" + Model.ToString());
        movespeed = reader.Search<float>("movespeed" + Model.ToString());
        PrefubId = reader.Search<int>("PrefubId");
        targetLimit = reader.Search<int>("targetLimit" + Model.ToString());
        pler = GetComponentInParent<Player>();
        

    }
    private void Awake()
    {
       //액션 실행시 작동하는거 
        GetCount=(int a)=> {
            if (a == 0)
            {
                return getCount();
            }
            else
            {
                return GetDamage();
            }
        };
        DeleteWeapon = () => {
            StopWeapon();
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer > Speed && !stop)
        {
            timer = 0;
           
                FireShhooting();
         
        }


    }


   
    public void StopWeapon()
    {
        stop = true; 
    }

    public void FireShhooting()
    {
        if (pler.mobscan.nearestTarget == null)
        {
            return;
        }
        int numberOfProjectiles = targetLimit; // 발사되는 탄환 수
        float angleInterval = 90f / (numberOfProjectiles - 1); // 탄환 각도 간격 계산

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // 타겟을 향하는 각도 계산
            float targetAngle = Mathf.Atan2(pler.mobscan.nearestTarget.position.y - transform.position.y, pler.mobscan.nearestTarget.position.x - transform.position.x) * Mathf.Rad2Deg;

            // 탄환의 각도 계산
            float bulletAngle = targetAngle - 45f + (angleInterval * i);

            // 각도를 라디안으로 변환
            float radians = bulletAngle * Mathf.Deg2Rad;

            // 새로운 방향 벡터를 계산
            Vector3 newDir = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians));

            Transform bullset = GameManager.instance.WaPolManage.GetPoolsPrefabs(PrefubId).transform;
            
            bullset.position = transform.position;
            bullset.rotation = Quaternion.FromToRotation(Vector3.up, newDir);
            bullset.GetComponent<Shooting_Wappon>().Init(Damage, newDir, movespeed);


        }
    }
 

    public int getCount()
    {
        return (int)Speed;
    }

    public int GetDamage()
    {
        return (int)Damage;
    }
    public void DamageUp(float damage)
    {
        this.Damage += damage;
    }
}
