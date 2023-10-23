using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updategold : MonoBehaviour
{
    public Text thistext;
      // Start is called before the first frame update
    void Start()
    {
        ConfigReader reader = new ConfigReader("Player");
        int goldnum = reader.Search<int>("gold");
        thistext.text = goldnum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ConfigReader reader = new ConfigReader("Player");
        int goldnum = reader.Search<int>("gold");
        thistext.text = goldnum.ToString();
    }
}
