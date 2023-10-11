using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    RectTransform rect;
    public GameObject target;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        followTarget(target);
    }
    public void followTarget(GameObject obj) {
        rect.position = Camera.main.WorldToScreenPoint(obj.transform.position);
    }
    public void destroythis()
    {
        Destroy(gameObject);
    }
}
