using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class ItemParent : MonoBehaviour
{
    private int limit=1;
    private float spawnChance;

    public int getLimit()
    {
        return this.limit;
    }
    public void DeleteList()
    {
        GameManager.instance.DropManage.DeleteItemList(gameObject);
    }
}
