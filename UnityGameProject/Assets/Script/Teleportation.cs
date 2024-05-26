using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject player;   // 플레이어 오브젝트
    public GameObject telePos;  // 텔레포트 목표점 오브젝트

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")      // 플레이어 충돌시
        {
                Vector3 Pos = telePos.transform.position;    // 텔레포트 위치 = telePos 오브젝트의 위치
                Pos += Vector3.up * 2;      // 위치 보정
                player.transform.position = Pos;     // 텔레포트 위치로 플레이어 이동   
        }
    }
    
}

