using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownWall1 : MonoBehaviour
{
    public float speed = 4.0f;                // �̵� �ӵ�
    public float maxHeight = 10.0f;            // �ִ� ����
    public float minHeight = -8.0f;           // �ּ� ����

    private bool movingUp = true;             // ������Ʈ�� ���� �����̴��� ���θ� ��Ÿ���� �÷���


    void Update()
    {
        // ���� �����̴� ���
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); // �������� �̵�

            // �ִ� ���̿� �����ϸ� ������ �ݴ�� ����
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }
        }

        // �Ʒ��� �����̴� ���
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); // �Ʒ������� �̵�

            // �ּ� ���̿� �����ϸ� ������ �ݴ�� ����
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }
        }
    }
}

