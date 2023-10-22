using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearSecUI : MonoBehaviour
{
    public GameObject child;
    Image image;
    Color color;
    float startA;
    RectTransform tras;
    public float endTime;
    float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        image = child.GetComponent<Image>();
        tras = child.GetComponent<RectTransform>();
        color = image.color;
        startA = color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (endTime < timer)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        color.a = startA*(1 - timer/endTime);
        image.color = color;
    }
}
