using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FollowCamera : MonoBehaviour
{
    Transform trans;
    Player player;
    public Text[] textLabels; // UI Text 배열
    public GameObject[] gameobj;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        player = GameManager.instance.player;
    }

    private void FixedUpdate()
    {
        trans.position = player.transform.position + new Vector3(0, 0, -10);

        // UI Text 업데이트 함수 호출
        UpdateTextLabels();
    }
    void UpdateTextLabels()
    {
        if (textLabels != null)
        {
            for (int i = 0; i < textLabels.Length; i++)
            {
                if (textLabels[i] != null)
                {
                    Vector3 textLabelsPos = Camera.main.WorldToScreenPoint(gameobj[i].transform.position);

                    textLabels[i].rectTransform.position = textLabelsPos;
                }
            }
        }
    }
}