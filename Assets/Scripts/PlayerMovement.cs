using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float gravityForce;

    [SerializeField] private float checkDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform playerMesh;

    [SerializeField] private bool canJump;
    [SerializeField] private bool canMove;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MyGravity();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 MoveDirection = forward * verticalInput + right * horizontalInput;

        rb.velocity = new Vector3(MoveDirection.x * speed, rb.velocity.y, MoveDirection.z * speed);

        if(MoveDirection != Vector3.zero)
        {
            playerMesh.rotation = Quaternion.LookRotation(MoveDirection);
        }
    }

    private void Update()
    {
        canJump = Physics.CheckSphere(groundCheck.position, checkDistance, groundMask);
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void MyGravity()
    {
        rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * gravityForce);
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = Vector3.up * jumpForce;
            GameManager.Instance.JumpsCounterUpdate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkDistance);
    }
}
