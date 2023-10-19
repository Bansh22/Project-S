using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Short_Pattern_Bomb: MonoBehaviour
{
    public GameObject[] Pattern;
    private Player player;
    public float endTimer;
    float startTimer=0;

    float timer = 0;
    float rate = 0.8f;
    float angle = 0;
    bool finsh = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        startTimer = GameManager.instance.gameTime;
        timer = startTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.gameTime - startTimer < endTimer && player.getLive())
        {
            if (GameManager.instance.gameTime-timer > rate)
            {
                timer = GameManager.instance.gameTime;
                GameObject pat=Instantiate(Pattern[0], player.transform.position, Quaternion.identity);
                PatternTimer patInfo= pat.GetComponent<PatternTimer>();
                //x = centerX + radius * cos(angle)
                //y = centerY + radius * sin(angle)
                patInfo.dir = Vector3.up;
                pat.transform.parent = transform;
                pat.SetActive(true);
                angle+=36;
            }
        }
        else if(!finsh)
        {
            StartCoroutine(Finsh());
            finsh = true;
        }
    }
    IEnumerator Finsh()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
