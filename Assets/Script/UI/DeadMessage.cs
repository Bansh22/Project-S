using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMessage : MonoBehaviour
{
    Player player;
    bool onetime = true;
    public GameObject Finsh;
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
            Finsh.SetActive(true);
        }
        else if(player.getLive())
        {
            onetime = true;
        }
    }
}
