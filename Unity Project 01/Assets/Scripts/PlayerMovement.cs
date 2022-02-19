using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {  // m_Animator 를 GetComponent 리스트에 있는 Animator에 참조

        m_Animator = GetComponent<Animator> ();

           // m_Rigidbody 를 GetComponent 리스트에 있는 Rigidbody에 참조

        m_Rigidbody = GetComponent<Rigidbody> ();
        
    }

    // Update -> 스크립트가 enabled 상태일때 매 프레임마다 호출됨
    // 물리효과가 적용되지 않은 오브젝트의 움직임이나 단순한 타이머, 키입력을 받을때 사용
    // (Update는 불규칙한 호출임으로 물리엔진 충돌검사 등이 제대로 안될수 있음)

    // FixedUpdate -> FixedTimestep에 설정된 값에 따라 일정한 간격으로 호출됨
    // 물리효과가 적용된 (Rigidbody) 오브젝트를 조정할때 사용
    
    void FixedUpdate()
    {
        // 입력하면 이동하는 값 설정

        float h = Input.GetAxis ("Horaizontal");
        float v = Input.GetAxis ("Vertical");

        // vertor3(이동하는값) 정규화
        // - > 피타고라스의 법칙으로 1과 1이 사이에 거리 즉 대각선 이동값은
        // 1을 (대략 1.44) 초과하기 때문

        m_Movement.Set(h, 0, v);
        m_Movement.Normalize ();


        // 플레이어 입력 감지
        // 논리 연산자 (||)로 둘중하나 또는 모두 true이면 true가 되고
        // 둘다 false 상태면 false가 된다

        bool hasHoraizontalInput = !Mathf.Approximately(h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = hasHoraizontalInput || hasVerticalInput;

        // GetComponent에 참조 한 값(m_Animator)을 SetBoll 함수를 사용하여
        // IsWalking 파라미터로 지정해서 넣음

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 Forward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(Forward);
    }
    // OnAnimatorMove 이동과 회전을 개별적으로 적용하는 메서드
    private void OnAnimatorMove()
    {
        // deltaPosition ->  루트 모션으로 인한 프레임당 포지션의 이동량

        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
