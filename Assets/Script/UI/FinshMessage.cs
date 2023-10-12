using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshMessage : MonoBehaviour
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

            Wappon_Manager.DeleteWeapon();
        }
        else if(player.getLive())
        {
            onetime = true;
        }
        if (GameManager.instance.gameTime >= GameManager.instance.maxGameTime) { 
            Finsh.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
