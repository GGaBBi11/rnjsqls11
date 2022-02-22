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
    {  // m_Animator �� GetComponent ����Ʈ�� �ִ� Animator�� ����

        m_Animator = GetComponent<Animator> ();

           // m_Rigidbody �� GetComponent ����Ʈ�� �ִ� Rigidbody�� ����

        m_Rigidbody = GetComponent<Rigidbody> ();
        
    }

    // Update -> ��ũ��Ʈ�� enabled �����϶� �� �����Ӹ��� ȣ���
    // ����ȿ���� ������� ���� ������Ʈ�� �������̳� �ܼ��� Ÿ�̸�, Ű�Է��� ������ ���
    // (Update�� �ұ�Ģ�� ȣ�������� �������� �浹�˻� ���� ����� �ȵɼ� ����)

    // FixedUpdate -> FixedTimestep�� ������ ���� ���� ������ �������� ȣ���
    // ����ȿ���� ����� (Rigidbody) ������Ʈ�� �����Ҷ� ���
    
    void FixedUpdate()
    {
        // �Է��ϸ� �̵��ϴ� �� ����

        float h = Input.GetAxis ("Horaizontal");
        float v = Input.GetAxis ("Vertical");

        // vertor3(�̵��ϴ°�) ����ȭ
        // - > ��Ÿ����� ��Ģ���� 1�� 1�� ���̿� �Ÿ� �� �밢�� �̵�����
        // 1�� (�뷫 1.44) �ʰ��ϱ� ����

        m_Movement.Set(h, 0, v);
        m_Movement.Normalize ();


        // �÷��̾� �Է� ����
        // �� ������ (||)�� �����ϳ� �Ǵ� ��� true�̸� true�� �ǰ�
        // �Ѵ� false ���¸� false�� �ȴ�

        bool hasHoraizontalInput = !Mathf.Approximately(h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = hasHoraizontalInput || hasVerticalInput;

        // GetComponent�� ���� �� ��(m_Animator)�� SetBoll �Լ��� ����Ͽ�
        // IsWalking �Ķ���ͷ� �����ؼ� ����

        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 Forward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(Forward);
    }
    // OnAnimatorMove �̵��� ȸ���� ���������� �����ϴ� �޼���
    private void OnAnimatorMove()
    {
        // deltaPosition ->  ��Ʈ ������� ���� �����Ӵ� �������� �̵���

        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

}
