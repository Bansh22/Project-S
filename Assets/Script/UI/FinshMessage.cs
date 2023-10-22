using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshMessage : MonoBehaviour
{
    Player player;
    public GameObject Finsh;
    private void Start()
    {
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.getLive() && Time.timeScale!=0)
        {
            nearing_Wappon_Manager.DeleteWeapon();
            Shooting_Wappon_Manager.DeleteWeapon();
            StartCoroutine(DeadEvent());
        }
        if (GameManager.instance.gameTime >= GameManager.instance.maxGameTime) { 
            Finsh.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    IEnumerator DeadEvent()
    {
        Time.timeScale = 0.2f;
        while (!player.getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Dead"))
        {
            yield return new WaitForFixedUpdate();
        }
        float startCamera = Camera.main.orthographicSize;
        while (player.getAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            Camera.main.orthographicSize = 1.5f + (startCamera - 1) * (1-player.getAnimator().GetCurrentAnimatorStateInfo(0).normalizedTime);
            yield return new WaitForFixedUpdate();
        }
        Finsh.SetActive(true);
        Time.timeScale = 0f;
    }
}
