using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyManager : MonoBehaviour
{
    private float fireDamage;
    private float fireRate;
    private float fireSpeed;
    EnemyType1 enemyInfo;
    private float fireRand;
    private float timer;
    private Player player;
    private void Start()
    {
        enemyInfo = gameObject.GetComponentInParent<EnemyType1>();
        fireDamage = enemyInfo.getFireDamage();
        fireRate = enemyInfo.getFireRate();
        fireSpeed = enemyInfo.getFireSpeed();
        fireRand = Random.Range(-0.5f, 0.5f);
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!enemyInfo.getLive())
            return;
        timer += Time.deltaTime;
        if(timer> (fireRate + fireRand) - 0.4 && player.getLive() && !enemyInfo.getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            enemyInfo.getAnimator().SetBool("Charge",true);
        }
        if (timer > (fireRate+ fireRand))
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
        shoot.GetComponent<EnemyProjectil>().Init(fireDamage, dir, fireSpeed);
    }
}
