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
            // 1. 만약에 Player Y축 각도가 0도가 아니면 0 될때까지 회전
            // 2. 앞으로 전진
            tmpDir = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // 1. 만약에 Player Y축 각도가 180도가 아니면 180도가 될때까지 회전
            // 2. 뒤로 전진.
            tmpDir = Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 1. 만약에 Player Y축 각도가 270도가 아니면 270도가 될때까지 회전
            // 2. 왼쪽으로 전진
                tmpDir = (tmpDir + Vector3.left).normalized;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // 1. 만약에 Player Y축 각도가 90도가 아니면 90도가 될때까지 회전
            // 2. 오른쪽으로 전진
            tmpDir = (tmpDir + Vector3.right).normalized;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 1. 점프하기
        }


        direction = tmpDir;
    }
}
