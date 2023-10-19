using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // H 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.H))
        {
            // "HKeyPressed" 트리거를 활성화하여 애니메이션 전환
            animator.SetTrigger("HKeyPressed");
        }
    }
}
