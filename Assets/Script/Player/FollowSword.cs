using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSword : MonoBehaviour
{
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
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
