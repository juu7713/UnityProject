using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBar : MonoBehaviour
{
    public float speed = 5f;    // 회전속도
    public bool right = true;   // 회전방향

    
    void Update()
    {
        if (right)      // 오른쪽으로 회전
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime / 0.01f, Space.Self);    // local 좌표 기준 회전
        }
        else        // 왼쪽으로 회전
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime / 0.01f, Space.Self);
        }
    }
}
