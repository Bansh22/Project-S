using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMessage : MonoBehaviour
{
    Player player;
    bool onetime = true;
    public GameObject child;
    WaitForFixedUpdate wait;
    private void Start()
    {
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.getLive() && onetime)
        {
            onetime = false;
            StartCoroutine(WaitMessage());
        }
        else
        {
            onetime = true;
        }
    }
    IEnumerator WaitMessage()
    {
        yield return wait;
        while (!(player.getAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime >= player.getDeadMotion()))
        {
            yield return wait;
        }
        child.SetActive(true);
    }
}
