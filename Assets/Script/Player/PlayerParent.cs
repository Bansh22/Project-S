using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[SerializeField]
public class PlayerParent : MonoBehaviour
{
    //캐릭터변경
    public  RuntimeAnimatorController[] Player_Controller;
    //컴포넌트 기능 Get함수로 반환
    private GameObject mine;
    private Transform trans;
    private Rigidbody2D rigid;
    private SpriteRenderer render;
    private Animator anim;
    private Collider2D coll;
    
    //npc 관련 변수
    private Collider2D npc;
    private bool Innpc;
    private bool canInteract = true; // E 키 입력을 받을 수 있는 상태인지를 나타내는 변수
    private float interactCooldown = 0.5f; // E 키 입력 간격을 제어하는 변수
    public GameObject[] canvases; // 0 messagecanvas 1 totucanvas 2 charcanvas 3 upgradecanvas 4pause
    
    public GameObject textmessage;
    private Material npcMaterial;
    //Set ,Get 있는 친구들 , 꺼내오고 , 값을 수정하는 함수가 있다 
    //player 스피드
    private float speed; //(config 등록)
    //player 최대 체력
    private float MaxHp; 
    //player 체력
    private float hp; //(config 등록)


    // Set, Get 이 있고 Change가 있는 함수, 
    private bool isLive; 

    // Set, Get 이 있고 KnockBack와 관련 있는 함수,
    //knock back이 되는지
    private bool isKnock;//넉백
    //knock back 물리적 힘
    private float KnockForce;
    //fixedUpdate 시간만큼 기다리는 변수
    WaitForFixedUpdate wait;
    float hitTime=0;
   
    //
    //TakeDamage 변수 : damage  받아서, hp를 깎는다 
    //hp 가 0보다 작으면  gameobject 를 비활성화 시킨다 
    //hp 가 0보다 크면 hit 애니메이션 작동 후 일정 거리 넉백한다.

    public void Awake()
    {
        Innpc = false;
        // ConfigReader 초기화
        ConfigReader reader = new ConfigReader("Player");
        int modelIndex = reader.Search<int>("Model");
        Animator change = GetComponent<Animator>();
        change.runtimeAnimatorController = Player_Controller[modelIndex];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RelationE"))
        {
            npc = collision;
            Innpc = true;
          

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RelationE"))
        {
            npc = null;
            Innpc = false;
          
        }
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvases[4].SetActive(true);
        }
        
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            
         
            if (Innpc)
            {
                RelObject_keydownE relObject = npc.GetComponent<RelObject_keydownE>();
                if (relObject != null)
                {
                  
                    // 랜덤한 메시지 가져오기
                    string[] messages = relObject.message;
                    if (messages.Length > 0)
                    {
                        if (messages.Length > 4)
                        {
                            if (relObject.npcname != null)
                            {
                                if ("charator" == relObject.npcname)
                                {
                                    try
                                    {
                                        canvases[2].SetActive(true); //charator 
                                    }
                                    catch
                                    {
                                        Debug.LogError("캔버스 2없음 ");
                                    }
                                }
                                if ("hpshop" == relObject.npcname)
                                {
                                    try
                                    {
                                        canvases[3].SetActive(true); //charator 
                                    }
                                    catch
                                    {
                                        Debug.LogError("캔버스 3없음 ");
                                    }
                                }
                                if ("magicshop" == relObject.npcname)
                                {
                                    try
                                    {
                                        canvases[5].SetActive(true); //charator 
                                    }
                                    catch
                                    {
                                        Debug.LogError("캔버스 5없음 ");
                                    }
                                }
                                if ("weaponshop" == relObject.npcname)
                                {
                                    try
                                    {
                                        canvases[6].SetActive(true); //charator 
                                    }
                                    catch
                                    {
                                        Debug.LogError("캔버스 6없음 ");
                                    }
                                }

                            }
                            else
                            {
                                Debug.LogError("npc이름 없음!");
                            }
                        }
                        else
                        {
                            int randomIndex = Random.Range(0, messages.Length);
                            string randomMessage = messages[randomIndex];
                            int ranval = Random.Range(50, 101);
                            try
                            {
                                canvases[0].SetActive(true); //messagecanvas

                                if (randomMessage.Contains("Gold"))
                                {
                                    ConfigReader reader = new ConfigReader("Player");
                                    int goldnum = reader.Search<int>("gold");
                                    goldnum += ranval;
                                    reader.UpdateData("gold" , goldnum.ToString());
                                  

                                    npc.gameObject.transform.parent.gameObject.SetActive(false);
                                }
                            }
                            catch
                            {
                                npc.gameObject.transform.parent.gameObject.SetActive(false);
                                Debug.LogError("캔버스 0없음 ");
                            }
                            Text textmes = textmessage.GetComponent<Text>();
                            textmes.text = randomMessage + "\n" + ranval.ToString() +"Gold Get!" ;
                            //Debug.Log(randomMessage);
                        }

                    }
                    else if(messages.Length == 0)
                    {
                        try
                        {
                            canvases[1].SetActive(true);
                        }
                        catch
                    {
                        Debug.LogError("캔버스 1없음 ");
                    }
                }
                }

                // 입력 간격 동안 비활성화
                canInteract = false;
                StartCoroutine(EnableInteractAfterCooldown());
            }
        }
    }
 





    private IEnumerator EnableInteractAfterCooldown()
    {
        yield return new WaitForSeconds(interactCooldown);
        canInteract = true;
    }

    public void ChangeCharacterSprite(int index)
    {
        ConfigReader reader = new ConfigReader("Player");
        reader.UpdateData("Model", index.ToString());
        GameManager.instance.player.getAnimator().runtimeAnimatorController= GameManager.instance.player.Player_Controller[index];
    }

    public void takeDamage(float damage)
    {
        hp -= damage; // 데미지 받는다
        if (hitTime == 0)
        {
            hitTime = GameManager.instance.gameTime;
        }
        if (hp <= 0) //0보다 작으면 
        {
            hp = 0f;
            anim.SetTrigger("Dead");
            setLive(false);
            coll.enabled = false;//시체 충돌 무시
            StartCoroutine(Dead());

        }
        else if (hp > 0)
        {
             StartCoroutine(HitColor());
            if (isKnock)
            {
                //변수에 따라 넉백 작동
                StartCoroutine(KnockBack());
            }
        }
    }
    //코루틴으로 넉백 작동
    //현재 유저 위치와 반대로 밀림
    //KnockForce로 밀리는 정도 조절가능

    IEnumerator KnockBack()
    {
        //FixedUpdate 시간 만큼 정지
        yield return wait;
        //플레이어 위치
        Vector3 plyPos = GameManager.instance.player.transform.position;
        //현 위치 - 플레이어 위치
        Vector3 dirVec = transform.position - plyPos;
        //물리 컴포넌트
        //ForceMode2D.Impulse으로 순간적인 힘 적용
        rigid.AddForce(dirVec.normalized * KnockForce, ForceMode2D.Impulse);
    }
    IEnumerator HitColor()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if (GameManager.instance.gameTime- hitTime >= 0.15f)
        { 
            render.color = Color.white;
            hitTime = 0;
        }
    }
    //플레이어 죽임
    IEnumerator Dead()
    {
        rigid.velocity = Vector3.zero;
        yield return wait;
        while (!(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >=1))
        {
            yield return wait;
        }
        //정산용 코드 필요 
        AudioManageer.instance.StopBgm();
    }


    //Revive 함수 , 변수를 hp 로 받아서 최대체력으로 현재 hp 를 만들어준다 
    //초기화 목록
    //hp
    //isLive
    //HpBarUI
    //setActive
    //coll.enabled
    public void Revive()
    {
        GameManager.instance.uiManger.addUI(0, gameObject);
        this.hp = this.MaxHp;
        anim.SetTrigger("Live");
        gameObject.SetActive(true);
        coll.enabled = true;//충돌 허용
        setLive(true);
    }

    //포션 관련 코드
    public void Healing(float heal)
    {
        hp += heal;
        if (hp > MaxHp)
        {
            hp = MaxHp;
        }
    }
    public void SpeedBuff(float buff)
    {
        speed = speed * (1 + buff);
    }
    public void HpBuff(float buff)
    {
        MaxHp += buff;
    }

    //Speed 관련 코드 
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public float getSpeed()
    {
        return this.speed;
    }

    //MaxHp 관련 코드 
    public void setMaxHp(float MaxHp)
    {
        this.MaxHp = MaxHp;
    }
    public float getMaxHp()
    {
        return this.MaxHp;
    }

    //Hp 관련 코드 
    public void setHp(float hp)
    {
        this.hp = hp;
    }
    public float getHp()
    {
        return this.hp;
    }

    // Live 관련 코드 
    public void setLive(bool live)
    {
        this.isLive = live;
    }
    public bool getLive()
    {
        return this.isLive;
    }
    public void ChangeLive()
    {
        isLive = !isLive;
    }

    //KnockBack 관련 함수
    public void setKnock(bool Knock)
    {
        this.isKnock = Knock;
    }
    public bool getKnock()
    {
        return this.isKnock;
    }
    public void setKnockForce(float KnockForce)
    {
        this.KnockForce = KnockForce;
    }
    public float getKnockForce()
    {
        return this.KnockForce;
    }

    //컴포넌트 설정
    public void setObject()
    {
        //컴포넌트 설정되어있는 확인용
        mine = gameObject;
        //벡터 컴포넌트
        trans = gameObject.GetComponent<Transform>();
        //애니메 컴포넌트
        anim = gameObject.GetComponent<Animator>();
        //랜더 컴포넌트
        render = gameObject.GetComponent<SpriteRenderer>();
        //물리 컴포넌트
        rigid = gameObject.GetComponent<Rigidbody2D>();
        //충돌 컴포넌트
        coll = gameObject.GetComponent<Collider2D>();
    }
    public Transform getTransform()
    {
        return trans;
    }
    public Animator getAnimator()
    {
        return anim;
    }
    public SpriteRenderer getSpriteRenderer()
    {
        return render;
    }
    public Rigidbody2D getRigidbody2D()
    {
        return rigid;
    }
    public Collider2D getCollider2D()
    {
        return coll;
    }
}
