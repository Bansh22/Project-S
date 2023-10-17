using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyManager : MonoBehaviour
{
    private float damage;
    private float rate;
    private float movespeed;
    EnemyType1 enemyInfo;

    private float timer;
    private Player player;
    private void Start()
    {
        enemyInfo = gameObject.GetComponentInParent<EnemyType1>();
        damage = enemyInfo.getDamage();
        rate = 2f;
        movespeed = 5;
        player = GameManager.instance.player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > rate)
        {
            timer = 0;
            FireShhooting();
        }


    }

    public void FireShhooting()
    {

        if (!player.getLive())
        {
            return;
        }

        Vector3 targetpos = player.transform.position;
        Vector3 dir = targetpos - transform.position;
        if (dir.magnitude > 16)
            return;
        dir = dir.normalized;

        GameObject bullset= enemyInfo.projectil;
        GameObject shoot=Instantiate(bullset, transform.position, bullset.transform.rotation);
        shoot.transform.parent = transform;
        shoot.transform.rotation = shoot.transform.rotation*Quaternion.FromToRotation(Vector3.up, dir);
        shoot.GetComponent<EnemyProjectil>().Init(damage, dir, movespeed);
    }
}
