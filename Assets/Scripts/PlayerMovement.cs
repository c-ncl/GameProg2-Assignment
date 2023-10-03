using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;

    public float walkSpeed = 5;
    public float runSpeed = 8; 
    public float jumpHeight = 2;
    public float gravity = -9.18f;
    public float mouseSensitivy = 5.0f;
    
    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        ProcessMovement();
        UpdateRotation();
    }

    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivy, 0, Space.Self);
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }

    void UpdateAnimator()
    {
        bool isGrounded = controller.isGrounded; 

        if(move != Vector3.zero)
        {
            if(GetMovementSpeed() == runSpeed)
            {
                animator.SetFloat("Speed", 1.0f);
            } else {
                animator.SetFloat("Speed", 0.5f);
            }
            
        } else {
            animator.SetFloat("Speed", 0.0f);
        }

        animator.SetBool("isGrounded", isGrounded);
    }

    void ProcessMovement()
    { 
        bool isGrounded = controller.isGrounded; 
        float speed = GetMovementSpeed();
 
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
 
        cameraForward.y = 0;
        cameraRight.y = 0;
 
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
        move = moveDirection.normalized * GetMovementSpeed() * Time.deltaTime;

        if (isGrounded)
        {
            if (playerVelocity.y < 0.0f)
            {
                playerVelocity.y = -1.0f;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime + move);
    }

    void ProcessGravity()
    {
        bool isGrounded = controller.isGrounded; 

        if (isGrounded)
        {
            if (playerVelocity.y < 0.0f)
            {
                playerVelocity.y = -1.0f;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime + move);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // bool hasBluePU = controller.hasBluePU; 
        if(other.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            // animator.SetBool("hasBluePU", hasBluePU);
            Debug.Log("Got the blue power up!");
        }
    }
}
