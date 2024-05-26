using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 2f;

    private Vector3 initialPosition;
    private Vector3 endPosition;
    private bool moveDirection = true;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        endPosition = transform.position + Vector3.up * distance;
    }

    // Update is called once per frame
    void Update()
    {

        /*transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);*/
        
    }

    private void FixedUpdate()
    {
        if (transform.position == initialPosition)
        {
            moveDirection = true;
        }
        else if (transform.position == endPosition)
        {
            moveDirection = false;
        }

        if (moveDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Hit();
            }
        }
    }
}
