using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Manage : MonoBehaviour
{
    //data part
    public GameObject[] dropPrefabs;
    public enum Drop
    {
        Heal,
        HP,
        Speed,
        WPCount,
        WPDamage,
        WPSpeed,
    }

    //manage part
    Dictionary<Drop, int> limitPrefabs;
    Dictionary<int, GameObject> createdPrefabs;
    int allItemNum=0;
    private void Awake()
    {
        limitPrefabs = new Dictionary<Drop, int>();
        createdPrefabs = new Dictionary<int, GameObject>();
    }

    public void Init()
    {
        limitPrefabs.Clear();
        createdPrefabs.Clear();
    }

    public bool DropItem(Drop drop, Vector3 position)
    {
        try
        {
            //아이템 제한수
            int itemNum = 0;
            if (limitPrefabs.TryGetValue(drop, out itemNum))
            {
                int limitItemNum = LimitItem(drop);
                if (itemNum < limitItemNum || limitItemNum == 0)
                {
                    limitPrefabs[drop] = itemNum++;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                limitPrefabs.Add(drop, 1);
            }
            //아이템 생성
            GameObject dropItem =Instantiate(dropPrefabs[(int)drop], position, Quaternion.identity);
            dropItem.transform.parent = transform;
            //떨어진 아이템에 등록
            createdPrefabs.Add(dropItem.GetInstanceID(), dropItem);
            allItemNum++;
            return true;
        }
        catch
        {
            Debug.Log("아이템 생성실패");
            return false;
        }
    }

    public int GetDropIndex(GameObject obj)
    {
        for (int i= 0;i < dropPrefabs.Length; i++)
        {
            if (dropPrefabs[i] == obj)
            {
                return i;
            }
        }
        return -1;
    }

    public int LimitItem(Drop dropNum)
    {
        //드랍 아이템에 대한 부모 필요
        ItemParent item = dropPrefabs[(int)dropNum].GetComponent<ItemParent>();
        int limit = item.getLimit();
        return limit;
    }
    public void DeleteItemList(GameObject item)
    {
        int dropIndex = GetDropIndex(item);
        if (dropIndex == -1)
        {
            return;
        }
        //Drop_Manage.Drop drop = (Drop_Manage.Drop)(dropIndex);
        //int itemNum = 0;
        //if (limitPrefabs.TryGetValue(drop, out itemNum))
        //{
        //    int limitItemNum = LimitItem(drop);
        //    if (itemNum < limitItemNum || limitItemNum != 0)
        //    {
        //        limitPrefabs[drop] = itemNum--;
        //    }
        //}
        //생성된 목록에서 제거
        createdPrefabs.Remove(item.GetInstanceID());
    }
}
