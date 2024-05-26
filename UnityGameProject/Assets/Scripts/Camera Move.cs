using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject player;

    private Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.transform.position + position;
    }
}
