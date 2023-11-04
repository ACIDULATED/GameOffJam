using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 dir;
    Rigidbody rb;
    public float speed;
    public float jumpSpd;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.y * speed);
    }

    void OnWalk(InputValue iv)
    {
        dir = iv.Get<Vector2>();
    }
    void OnJump()
    {
        if (grounded == true)
            rb.velocity = new Vector3(rb.velocity.x, jumpSpd, rb.velocity.z);
    }

    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}
