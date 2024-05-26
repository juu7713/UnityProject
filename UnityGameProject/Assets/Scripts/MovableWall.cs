using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
	public float distance = 15f;	// 벽이 움직이는 거리
	public bool horizontal = true;	// true이면 x축 이동, false이면 z축 이동
	public bool right = true;	// 벽이 움직이는 방향
	public float speed = 1f;	// 벽이 움직이는 속도
	
	private bool isGoingOut = true;     // true이면 시작점에서 나가는 상태, false이면 시작점으로 돌아가는 상태
    private Vector3 startPos;   // 이동 시작점

    void Awake()
    {
        startPos = transform.position;  // 처음 위치를 시작점으로 지정
    }
        // Update is called once per frame
        void Update()
    {
        if (horizontal)     // 수평방향 이동
        {
            if (isGoingOut) // 시작점으로부터 이동하는 방향
            {
                if (right)  // 오른쪽 방향으로 이동할 경우
                {
                    if (transform.position.x < startPos.x + distance)   // 목표지점에 아직 도달하지 않았으면 목표지점 향해 이동
                    {
                        transform.position += Vector3.right * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = false; // 목표지점에 도달. 시작점으로 돌아가는 상태로 전환.
                }
                else  // 왼쪽 방향으로 이동할 경우
                {
                    if (transform.position.x > startPos.x - distance)
                    {
                        transform.position += Vector3.left * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = false;
                }
            }
            else    // 시작점으로 돌아가는 상태
            {
                if (right)  // 오른쪽 방향에서 돌아갈 경우
                {
                    if (transform.position.x > startPos.x)   // 시작점에서 떨어져 있으면 시작점으로 돌아가기
                    {
                        transform.position -= Vector3.right * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = true;  // 시작점으로 돌아온 상태. 다시 이동 준비.
                }
                else  // 왼쪽 방향에서 돌아갈 경우
                {
                    if (transform.position.x < startPos.x)
                    {
                        transform.position -= Vector3.left * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = true;
                }
            }
        }

        else    // 수직(z축)방향 이동
        {
            if (isGoingOut) // 시작점으로부터 이동하는 방향
            {
                if (right)  // 오른쪽 방향으로 이동할 경우
                {
                    if (transform.position.z < startPos.z + distance)   // 목표지점에 아직 도달하지 않았으면 목표지점 향해 이동
                    {
                        transform.position += Vector3.forward * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = false; // 목표지점에 도달. 시작점으로 돌아가는 상태로 전환.
                }
                else  // 왼쪽 방향으로 이동할 경우
                {
                    if (transform.position.z > startPos.z - distance)
                    {
                        transform.position += Vector3.back * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = false;
                }
            }
            else    // 시작점으로 돌아가는 상태
            {
                if (right)  // 오른쪽 방향에서 돌아갈 경우
                {
                    if (transform.position.z > startPos.z)   // 시작점에서 떨어져 있으면 시작점으로 돌아가기
                    {
                        transform.position -= Vector3.forward * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = true;  // 시작점으로 돌아온 상태. 다시 이동 준비.
                }
                else  // 왼쪽 방향에서 돌아갈 경우
                {
                    if (transform.position.z < startPos.z)
                    {
                        transform.position -= Vector3.back * Time.deltaTime * speed;
                    }
                    else
                        isGoingOut = true;
                }
            }
        }
    }
}
