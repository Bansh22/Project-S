using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform trans;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        player = GameManager.instance.player;
    }

    private void FixedUpdate()
    {
        trans.position = player.transform.position + new Vector3(0, 0, -10);
    }
}