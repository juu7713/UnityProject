using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBar : MonoBehaviour
{
    public float speed = 5f;    // ȸ���ӵ�
    public bool right = true;   // ȸ������

    
    void Update()
    {
        if (right)      // ���������� ȸ��
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime / 0.01f, Space.Self);    // local ��ǥ ���� ȸ��
        }
        else        // �������� ȸ��
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime / 0.01f, Space.Self);
        }
    }
}
