using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemgetter : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Gem"))
        {
            return;
        }

        collision.gameObject.SetActive(false);
        Wappon_Manager.CountTarget();
    }
}
