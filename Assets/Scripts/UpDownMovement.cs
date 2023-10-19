using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float movementDistance = 0.5f; // 움직일 거리
    public float movementSpeed = 4.0f; // 움직이는 속도

    private Vector3 initialPosition; // 초기 위치
    private bool isMovingUp = true; // 현재 위로 움직이는 중인지 여부

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // 위아래로 움직이는 애니메이션
        MoveUpDownAnimation();
    }

    void MoveUpDownAnimation()
    {
        // 움직일 거리만큼 이동
        float movementDelta = Mathf.PingPong(Time.time * movementSpeed, movementDistance);

        // 현재 위치 갱신
        transform.position = initialPosition + new Vector3(0f, movementDelta, 0f);
    }
}
