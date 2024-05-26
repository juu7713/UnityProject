using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    void OnCollisionEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // 플레이어 순간이동
        }
    }
    void Update()
    {
            
    }
}

