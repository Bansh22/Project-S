using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternTimer : MonoBehaviour
{
    public GameObject pattern;
    public Vector3 dir;
    // startTime is called before the first frame update
    void Start()
    {
        pattern.transform.rotation=Quaternion.FromToRotation(Vector3.up, dir);
        pattern.SetActive(true);
    }
}
