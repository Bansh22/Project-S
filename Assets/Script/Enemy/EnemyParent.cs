using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class EnemyParent : MonoBehaviour
{
    private float speed;
    private float hp;
    private float damage;
    private bool isLive;

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public float getSpeed()
    {
        return this.speed;
    }
    public void setHp(float hp)
    {
        this.hp= hp;
    }
    public float getHp()
    {
        return this.hp;
    }
    public void setDamage(float damage)
    {
        this.damage= damage;
    }
    public float getDamage()
    {
        return this.damage;
    }
    public void setLive(bool live)
    {
        this.isLive= live;
    }
    public bool getLive()
    {
        return this.isLive;
    }

    public void takeDamage(float damage)
    {
        this.hp -= damage;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }
}
