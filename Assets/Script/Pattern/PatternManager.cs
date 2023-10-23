using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public GameObject[] ShortPrefabs;
    public GameObject[] LongPrefabs;
    private float startTime;
    public float shortTimer;
    float shortCheck=0;
    public float longTimer;
    float longCheck=0;

    private void Start()
    {
        startTime = GameManager.instance.gameTime;
    }

    private void FixedUpdate()
    {
        if ((GameManager.instance.gameTime - startTime)% shortTimer< shortCheck)
        {
            shortCheck = 0;
            if (ShortPrefabs.Length != 0)
            {
                GameObject pattern = Instantiate(ShortPrefabs[(int)Random.Range(0, ShortPrefabs.Length)], GameManager.instance.player.transform.position,Quaternion.identity);
                pattern.transform.parent = transform;
                pattern.SetActive(true);
            }
        }
        else
        {
            shortCheck = (GameManager.instance.gameTime - startTime) % shortTimer;
        }
        if ((GameManager.instance.gameTime - startTime) % longTimer < longCheck)
        {
            longCheck = 0;
            startTime = GameManager.instance.gameTime;
            if (LongPrefabs.Length != 0)
            {
                GameObject pattern = Instantiate(LongPrefabs[(int)Random.Range(0, LongPrefabs.Length)], GameManager.instance.player.transform.position, Quaternion.identity);
                pattern.transform.parent = transform;
                pattern.SetActive(true);
            }
        }
        else
        {
            longCheck = (GameManager.instance.gameTime - startTime) % longTimer;
        }
    }
}
