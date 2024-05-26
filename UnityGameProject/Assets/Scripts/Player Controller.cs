using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 5f;
    public float jumpHeight = 5f;
    public float rotationSpeed = 10f;
    public int life = 5;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        dir.Normalize();
        
        CheckGround();

        if (Input.GetButtonDown("Jump") && ground)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, dir, rotationSpeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.transform.position + dir * speed * Time.deltaTime);
    }

    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            ground = true;
        }
        else
        {
            ground = false;
        }
    }

    public void Hit()
    {
        life = --life;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
