using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    RectTransform rect;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(position: target.transform.position);
    }
    public void destroythis()
    {
        Destroy(gameObject);
    }
}
