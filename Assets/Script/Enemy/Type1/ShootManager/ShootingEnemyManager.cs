using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyManager : MonoBehaviour
{
    EnemyParent enemyInfo;
    private float fireRand;
    private float timer;
    private Player player;
    private void Start()
    {
        enemyInfo = gameObject.GetComponentInParent<EnemyParent>();
        fireRand = Random.Range(-0.5f, 0.5f);
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enemyInfo.IsLive)
            return;
        timer += Time.deltaTime;
        if(timer> (enemyInfo.getFireRate() + fireRand) - 0.45 && player.getLive() && !enemyInfo.getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            enemyInfo.getAnimator().SetBool("Charge",true);
        }
        if (timer > (enemyInfo.getFireRate() + fireRand))
        {
            timer = 0;
            FireShhooting();
            fireRand = Random.Range(-0.5f, 0.5f);
            enemyInfo.getAnimator().SetBool("Charge",false);
        }


    }

    public void FireShhooting()
    {

        if (!player.getLive()  || enemyInfo.getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            timer = 0;
            return;
        }

        Vector3 targetpos = player.gameObject.transform.Find("Sap_Wappon_Manager").position;
        Vector3 dir = targetpos - transform.position;
        if (dir.magnitude > 16)
            return;
        dir = dir.normalized;

        GameObject bullset= enemyInfo.projectil;
        GameObject shoot=Instantiate(bullset, transform.position, bullset.transform.rotation);
        shoot.transform.parent = transform;
        shoot.transform.rotation = shoot.transform.rotation*Quaternion.FromToRotation(Vector3.up, dir);
        shoot.GetComponent<EnemyProjectil>().Init(enemyInfo.getFireDamage(), dir, enemyInfo.getFireSpeed());
    }
}
