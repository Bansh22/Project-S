using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Sign : MonoBehaviour
{
    public GameObject totupage;
    public GameObject totu_Sign;
    private bool isPlayerNear;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            totupage.SetActive(true);
            totu_Sign.SetActive(false);
            Invoke("MyFunction", 3.0f);
            MyFunction();
        }
    }
   
    void MyFunction()
    {
        totupage.SetActive(false);
        totu_Sign.SetActive(true);
    }


}
