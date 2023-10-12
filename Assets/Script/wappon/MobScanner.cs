using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScanner : MonoBehaviour
{

    public float ScanRange;
    public LayerMask targrtLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

  

    // Update is called once per frame
    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, ScanRange, Vector2.zero, 0, targrtLayer);
        nearestTarget = GetNearest();
        
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
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

}
