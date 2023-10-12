using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTile : MonoBehaviour
{
    public GameObject[] tiles;
    public float[] checkTile_x;
    public float[] checkTile_y;
    // Start is called before the first frame update
    void Start()
    {
        checkTile_x = new float[tiles.Length];
        checkTile_y = new float[tiles.Length];
    }

    private void FixedUpdate()
    {
        int n = 0;
        for(int i = 0; i < tiles.Length; i ++)
        {
            for(int j = i; j < tiles.Length; j++)
            {
                if(tiles[j].transform.position.x== tiles[i].transform.position.x)
                {
                    checkTile_x[i]= tiles[i].transform.position.x;
                }
            }
        }
        for (int i = 0; i < tiles.Length/2; i++)
        {
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j].transform.position.y == tiles[i].transform.position.y)
                {
                    checkTile_y[i] = tiles[i].transform.position.y;
                }
            }
        }
        Vector3 newPos = Vector3.zero;
        int wrongNum=-1;
        for(int i = 0; i < tiles.Length; i++)
        {
            if(checkTile_x[i] == 0 && checkTile_y[i] == 0)
            {
                wrongNum = i;
            }
            else
            {
                if(checkTile_x[i] == 0)
                {
                    newPos.y = tiles[i].transform.position.y;
                }
                else if(checkTile_y[i] == 0)
                {
                    newPos.x = tiles[i].transform.position.x;
                }
            }
        }
        if (wrongNum != -1)
        {
            tiles[wrongNum].transform.position = newPos;
        }

        checkTile_x = new float[tiles.Length];
        checkTile_y = new float[tiles.Length];
    }
}
