using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Transform trans;
    public float speed;
    public Vector2 inputVec;
    Animator anim;
    Rigidbody2D rigid;

    float speed;
    public Vector3 inputVec;

    // Start is called before the first frame update
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Start()
    {

        trans = GetComponent<Transform>();
        //sprite의 물리적 특성 (위치 크기 회전)
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        speed = GameManager.instance.speed;
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //Raw의 경우 0,1로 이진값으로 바꿔주는 장치
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //합산된 벡터 계산, normalized의 경우 x,y 벡터의 합이 1이상이 되기때문에 1로 고정
        //fixedDeltaTime의 경우 달라지는 프레임 대비
        rigid.MovePosition(rigid.position + nextVec);
        trans.Translate(nextVec);

        //위치 이동

        rigid.velocity = Vector3.zero;
    }


    void OnMove(InputValue val){
        inputVec = val.Get<Vector2>();
    }
}
