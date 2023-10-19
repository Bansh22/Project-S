using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSword : MonoBehaviour
{   
    //캐릭터변경
    public RuntimeAnimatorController[] WP_Controller;
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        ConfigReader reader = new ConfigReader("Player");
        int modelIndex = reader.Search<int>("Model");
        Animator change = GetComponent<Animator>();
        change.runtimeAnimatorController = WP_Controller[modelIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            mySR.flipX = false;
        }
        else if(Input .GetKey(KeyCode.LeftArrow))
        {
            mySR.flipX = true;
        }
    }
}
