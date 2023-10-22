using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupWp : Wappon
{
    //0:"UP", 1:"LEFT", 2:"DOWN", 3:"RIGHT"
    int[] command;
    int commandNum = 0;
    float inputDelay;
    float timer = 0;
    float coolTime;
    bool cool = true;

    Collider2D coll;
    Animator anim;
    SpriteRenderer render;
    private void Start()
    {
        command = new int[2];
        command[0] = 0;
        command[1] = 2;
        inputDelay = 0.4f;
        coolTime = 3;

        coll = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.player.inputVec.x > 0)
        {
            render.flipX = false;
        }
        else if (GameManager.instance.player.inputVec.x < 0)
        {
            render.flipX = true;
        }
        timer += Time.fixedDeltaTime;
        if (!cool)
        {
            if (timer > inputDelay)
            {
                timer = 0;
                commandNum = 0;
            }
            //커맨드 작동
            //bool result = InputCommand();
            //if (result)
            //{
            //    commandNum = 0;
            //    //무기작동
            //    FireShhooting();
            //}
            //시간 작동
            FireShhooting();
        }
        else
        {
            if (timer > coolTime)
            {
                cool = false;
                timer = 0;
            }
        }
    }
    public void FireShhooting()
    {
        if (GameManager.instance.player.mobscan.largeTarget == null)
        {
            return;
        }
        transform.position = GameManager.instance.player.mobscan.largeTarget.position;
        StartCoroutine(ActiveSkill());
    }

    IEnumerator ActiveSkill()
    {
        anim.SetTrigger("Skill");
        coll.enabled = true;
        cool = true;
        yield return new WaitForFixedUpdate();
        while (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Skill"))
        {
            yield return new WaitForFixedUpdate();
        } while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return new WaitForFixedUpdate();
        }
        coll.enabled = false;
        timer = 0;
    }
    public bool InputCommand()
    {
        int inputNum = -1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            inputNum = 0;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputNum = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            inputNum = 2;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputNum = 3;
        }
        if (command[commandNum] == inputNum)
        {
            commandNum++;
        }
        if (commandNum == command.Length)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
