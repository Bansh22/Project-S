using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMessage : MonoBehaviour
{
    Player player;
    bool onetime = true;
    public GameObject Dead;
    public GameObject Finsh;
    WaitForFixedUpdate wait;
    private void Start()
    {
        player = GameManager.instance.player;
        wait = new WaitForFixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.getLive() && onetime)
        {
            onetime = false;
            StartCoroutine(WaitMessage());
        }
        else if(player.getLive())
        {
            onetime = true;
        }
    }
    IEnumerator WaitMessage()
    {
        yield return wait;
        while (!(player.getAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            yield return wait;
        }
        Dead.SetActive(true);
        Debug.Log("작동");
        yield return new WaitForSeconds(0.2f);
        Debug.Log("작동1");
        Finsh.SetActive(true);
    }
}
