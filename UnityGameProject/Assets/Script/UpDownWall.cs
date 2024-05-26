using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownWall1 : MonoBehaviour
{
    public float speed = 4.0f;                // 이동 속도
    public float maxHeight = 10.0f;            // 최대 높이
    public float minHeight = -8.0f;           // 최소 높이

    private bool movingUp = true;             // 오브젝트가 위로 움직이는지 여부를 나타내는 플래그


    void Update()
    {
        // 위로 움직이는 경우
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); // 위쪽으로 이동

            // 최대 높이에 도달하면 방향을 반대로 변경
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }
        }

        // 아래로 움직이는 경우
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); // 아래쪽으로 이동

            // 최소 높이에 도달하면 방향을 반대로 변경
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }
        }
    }
}

