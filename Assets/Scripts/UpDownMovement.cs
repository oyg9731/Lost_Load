using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float movementDistance = 0.5f; // ������ �Ÿ�
    public float movementSpeed = 4.0f; // �����̴� �ӵ�

    private Vector3 initialPosition; // �ʱ� ��ġ
    private bool isMovingUp = true; // ���� ���� �����̴� ������ ����

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // ���Ʒ��� �����̴� �ִϸ��̼�
        MoveUpDownAnimation();
    }

    void MoveUpDownAnimation()
    {
        // ������ �Ÿ���ŭ �̵�
        float movementDelta = Mathf.PingPong(Time.time * movementSpeed, movementDistance);

        // ���� ��ġ ����
        transform.position = initialPosition + new Vector3(0f, movementDelta, 0f);
    }
}
