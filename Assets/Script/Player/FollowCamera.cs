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

    public float minX = -12f; // 최소 X 위치
    public float maxX = 12f;  // 최대 X 위치
    public float minY = -14f; // 최소 Y 위치
    public float maxY = 14f;  // 최대 Y 위치

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent < Transform>();
        player = GameManager.instance.player;
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(playerPosition.x, minX, maxX),
            Mathf.Clamp(playerPosition.y, minY, maxY),
            trans.position.z
        );

        // 카메라의 월드 좌표를 뷰포트 좌표로 변환
        Vector3 cameraViewportPosition = mainCamera.WorldToViewportPoint(targetPosition);

        // 뷰포트 좌표를 0과 1 사이로 제한
        cameraViewportPosition.x = Mathf.Clamp01(cameraViewportPosition.x);
        cameraViewportPosition.y = Mathf.Clamp01(cameraViewportPosition.y);

        // 제한된 뷰포트 좌표를 다시 월드 좌표로 변환
        targetPosition = mainCamera.ViewportToWorldPoint(cameraViewportPosition);

        // 카메라 위치 설정 (부드러운 이동을 위해 Lerp 사용)
        trans.position = Vector3.Lerp(trans.position, targetPosition, 0.1f);

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
                    Vector3 textLabelsPos = mainCamera.WorldToScreenPoint(gameobj[i].transform.position);

                    textLabels[i].rectTransform.position = textLabelsPos;
                }
            }
        }
    }
}
