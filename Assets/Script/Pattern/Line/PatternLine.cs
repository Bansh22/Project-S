using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternLine : MonoBehaviour
{
    public GameObject shootObj;
    public GameObject startObj;
    public GameObject parent;
    SpriteRenderer render;
    Color color;

    public float showTimer = 1;
    // Start is called before the first frame update
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        color = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine(ShowCircle());
    }
    IEnumerator ShowCircle()
    {
        yield return new WaitForSeconds(showTimer);
        color.a = 0;
        render.color = color;
        Vector3 targetpos = transform.position;
        Vector3 dir = targetpos - startObj.transform.position;
        dir = dir.normalized;
        GameObject shoot = Instantiate(shootObj, startObj.transform.position, shootObj.transform.rotation);
        shoot.SetActive(true);
        shoot.GetComponent<PatternShoot>().Init(dir);
    }
}

