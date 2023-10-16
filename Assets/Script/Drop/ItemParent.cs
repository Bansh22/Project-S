using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //set,get있음
    //월드에 있을 수 있는 제한시키는 변수
    //true: 제한이 1인 상태에서 1개를 먹으면 1개가 다시 안 떨어짐
    //false: 제한 1인 상태에서 1개를 먹어도 1개가 다시 떨어질수있음
    private bool worldLimit;

    //manager의 deleteList 메소드를 받아온다.
    public void DeleteList(Drop_Manage.Drop drop)
    {
        GameManager.instance.DropManage.DeleteItemList(drop,gameObject);
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
