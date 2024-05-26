using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private GameObject player;
    public float cameraPosition = 15;

    private Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        position = new Vector3(0, cameraPosition, -cameraPosition);
        this.transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.transform.position + position;
    }
}
