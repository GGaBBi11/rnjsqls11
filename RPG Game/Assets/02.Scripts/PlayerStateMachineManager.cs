using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    Vector3 direction;
    Vector3 move;

    private void Update()
    {
        Vector3 tmpDir = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 1. ���࿡ Player Y�� ������ 0���� �ƴϸ� 0 �ɶ����� ȸ��
            // 2. ������ ����
            tmpDir = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // 1. ���࿡ Player Y�� ������ 180���� �ƴϸ� 180���� �ɶ����� ȸ��
            // 2. �ڷ� ����.
            tmpDir = Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 1. ���࿡ Player Y�� ������ 270���� �ƴϸ� 270���� �ɶ����� ȸ��
            // 2. �������� ����
                tmpDir = (tmpDir + Vector3.left).normalized;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // 1. ���࿡ Player Y�� ������ 90���� �ƴϸ� 90���� �ɶ����� ȸ��
            // 2. ���������� ����
            tmpDir = (tmpDir + Vector3.right).normalized;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 1. �����ϱ�
        }


        direction = tmpDir;
    }
}
