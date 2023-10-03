using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform trans;
    public float speed;
    public Vector3 inputVec;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        trans = GetComponent<Transform>();
        //sprite의 물리적 특성 (위치 크기 회전)
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //Raw의 경우 0,1로 이진값으로 바꿔주는 장치
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        Vector3 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        //합산된 벡터 계산, normalized의 경우 x,y 벡터의 합이 1이상이 되기때문에 1로 고정
        //fixedDeltaTime의 경우 달라지는 프레임 대비
        trans.Translate(nextVec);
        //위치 이동
    }
}
