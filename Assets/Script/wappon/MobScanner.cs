using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScanner : MonoBehaviour
{

    public float ScanRange;
    public float areaRange;
    public LayerMask targrtLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;
    public Transform largeTarget;


    // 추가: 몹 그룹화를 위한 반지름
    public float groupRadius = 2f;
    // 추가: 몹 그룹을 저장할 리스트
    public List<List<Transform>> mobGroups = new List<List<Transform>>();
    // Update is called once per frame
    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, targrtLayer);
        nearestTarget = GetNearest();

        // 몹 그룹화
        largeTarget=GroupMobs();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }

    Transform GroupMobs()
    {
        mobGroups.Clear();

        foreach (RaycastHit2D mob in targets)
        {
            if(Vector3.Distance(mob.transform.position, transform.position) <= groupRadius)
            {
                continue;
            }
            bool grouped = false;

            foreach (List<Transform> group in mobGroups)
            {
                if (IsInGroup(mob.transform, group))
                {
                    group.Add(mob.transform);
                    grouped = true;
                    break;
                }
            }

            if (!grouped)
            {
                // 새로운 그룹 생성
                List<Transform> newGroup = new List<Transform>();
                newGroup.Add(mob.transform);
                mobGroups.Add(newGroup);
            }
        }

        // 가장 많은 몹이 모여 있는 그룹 찾기
        List<Transform> largestGroup = null;
        int maxMobCount = 0;

        foreach (List<Transform> group in mobGroups)
        {
            if (group.Count > maxMobCount)
            {
                maxMobCount = group.Count;
                largestGroup = group;
            }
        }

        // 가장 많은 몹이 모여있는 그룹을 찾았습니다.
        if (largestGroup != null)
        {
            return largestGroup[0];
        }
        return null;
    }
    // 추가: 몹이 그룹에 속하는지 확인
    bool IsInGroup(Transform mob, List<Transform> group)
    {
        if (Vector3.Distance(mob.position, group[0].position) <= groupRadius)
        {
            return true;
        }
        return false;
    }
}