using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemyType0 : EnemyParent
{ 
    //추적 대상 변수
    private Player tracePlayer;
    //현재 속도
    private Vector3 currentVelocity;
    private float smoothTime = 0.1f; // 관성을 부드럽게 만들기 위한 시간 설정
    
    //추적대상 수정
    public void setTracePlayer(Player player)
    {
        this.tracePlayer = player;
    }
    //현재 추적 대상 반환
    public Player getTarget()
    {
        return this.tracePlayer;
    }
    private void FixedUpdate()
    {
        //죽어있으면 작동정지 || Hit 태그 가진 애니메이션 끝날때 까지 작동 정지
        if (!getLive() || getAnimator().GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            return;
        }
        //추적 대상 설정
        setTracePlayer(GameManager.instance.player);
        //플레이어 추적
        playerTrace();
    }
    //추적대상 추적
    public void playerTrace()
    {
        //component 세팅 안되어있는경우 세팅
        if (getTransform()==null)
        {
            setObject();
        }
        Vector3 targetVelocity; // 목표 속도
        //현재 추적 대상 방향(현위치 - 대상위치) normalized:스칼라 1로 수정
        Vector3 moveVec = (tracePlayer.transform.position - getTransform().position).normalized;
      
        //목표속도= 방향 * 설정된 속도
        targetVelocity = moveVec * getSpeed();
        // 현재 속도를 부드럽게 조절하기
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref currentVelocity, smoothTime);
        // Rigidbody에 속도 적용
        getRigidbody2D().MovePosition(currentVelocity * Time.fixedDeltaTime + getTransform().position);
        //가속되는 속도 삭제
        getRigidbody2D().velocity = Vector3.zero;

        //가는 방향으로 몸 위치 변환
        getSpriteRenderer().flipX = moveVec.x < 0;

        ////포인트 이동(서브 이동방법)
        //getTransform().Translate(moveVec * getSpeed() * Time.fixedDeltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.takeDamage(getDamage()*Time.fixedDeltaTime);
        }
    }

    private void OnEnable()
    {
        //다시 나타날때 추적대상 설정
        setTracePlayer(GameManager.instance.player);
    }
}
