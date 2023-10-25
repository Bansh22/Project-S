using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[SerializeField]
public class ItemParent : MonoBehaviour
{
    //get 있음
    //제한수
    private int limit;
    //set,get있음
    //스폰 확률 (미구현)
    private float spawnChance;
    //set,get있음
    //효과 
    private float effect;
    private Transform tr ;
    //set,get있음
    //월드에 있을 수 있는 제한시키는 변수
    //true: 제한이 1인 상태에서 1개를 먹으면 1개가 다시 안 떨어짐
    //false: 제한 1인 상태에서 1개를 먹어도 1개가 다시 떨어질수있음
    private bool worldLimit;
    public float moveSpeed; // 이동 속도
    public float stoppingDistance; // 멈추는 거리

    public GameObject child;
    public GameObject[] kira;
    [HideInInspector] public Animator childAnim;
    [HideInInspector] public SpriteRenderer render;
    [HideInInspector] public Collider2D coll;
    [HideInInspector] public Color color;
    [HideInInspector] public float startA;
    //manager의 deleteList 메소드를 받아온다.
    public void DeleteList(Drop_Manage.Drop drop)
    {
        GameManager.instance.DropManage.DeleteItemList(drop,gameObject);
        StartCoroutine(Disappear());
    }
    private void OnEnable()
    {
        color = render.material.color;
        color.a = 0;
        render.color = color;
        StartCoroutine(Appear());
    }
    protected void Initialize()
    {
        tr = GetComponent<Transform>();
        moveSpeed = 0.5f;
        stoppingDistance = 10.0f;
    }



   

    public void Update()
    {
        float distance = Vector3.Distance(tr.position, GameManager.instance.player.transform.position);

        // 만약 현재 위치와 목표 위치 간의 거리가 특정 임계값보다 크다면 이동
        if (distance > stoppingDistance)
        {
            // Lerp를 사용하여 부드럽게 이동
            tr.position = Vector3.MoveTowards(tr.position, GameManager.instance.player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    IEnumerator Appear()
    {
        coll.enabled = false;
        while (childAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            color.a = startA * childAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            render.color = color;
            yield return new WaitForFixedUpdate();
        }
        color.a = 255;
        render.color = color;
        coll.enabled = true;
        foreach(GameObject k in kira)
        {
            k.SetActive(true);
        }
    }
    public IEnumerator Disappear()
    {
        childAnim.SetTrigger("Disappear");
        foreach (GameObject k in kira)
        {
            k.SetActive(false);
        }
        while (!childAnim.GetCurrentAnimatorStateInfo(0).IsTag("Disappear"))
        {
            yield return new WaitForFixedUpdate();
        }
        while (childAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            color.a = startA * (1 - childAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            render.color = color;
            yield return new WaitForFixedUpdate();
        }
        color.a = 0;
        render.color = color;
        Destroy(gameObject);
    }
    public int getLimit()
    {
        return this.limit;
    }
    public void setLimit(int limit)
    {
        this.limit= limit;
    }
    public float getChance()
    {
        return this.spawnChance;
    }
    public void setChance(float spawnChance)
    {
        this.spawnChance = spawnChance;
    }
    public float getEffect()
    {
        return this.effect;
    }
    public void setEffect(float effect)
    {
        this.effect = effect;
    }
    public bool getWorldLimit()
    {
        return this.worldLimit;
    }
    public void setWorldLimit(bool worldLimit)
    {
        this.worldLimit = worldLimit;
    }
}
