using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternCircle : MonoBehaviour
{
    public RuntimeAnimatorController[] animCon;
    public GameObject fallObj;
    public GameObject bombObj;
    public float damage;
    SpriteRenderer render;
    Color color;

    public float showTimer=1;
    bool onetime =false;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        color = render.material.color;
        Scene scene = SceneManager.GetActiveScene();
        //stage1 애니메이터 적용
        if (scene.name == "")
        {

        }
        //stage2 애니메이터 적용
        else if (scene.name == "")
        {

        }
        //stage3 애니메이터 적용
        else if (scene.name == "")
        {

        }
    }
    private void FixedUpdate()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine(ShowCircle());
    }
    IEnumerator ShowCircle() {
        yield return new WaitForSeconds(showTimer);
        color.a = 0;
        render.color = color;
        fallObj.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ThrowBomb") && collision.gameObject == fallObj)
        {
            Destroy(collision.gameObject);
            bombObj.GetComponent<PatternBomb>().Init(damage);
            bombObj.SetActive(true);
        }
    }
}
