using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float speed;

    Animator animator;
    Rigidbody rb;
    
    float xInput,yInput;
    int stateVelocityAnimation, stateDirecitonAnimation;
    bool sprinting;
    private Transform cameraTransform;

    public PhotonView photonView;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
        stateVelocityAnimation = Animator.StringToHash("velocity");
        stateDirecitonAnimation = Animator.StringToHash("direction");
        cameraTransform = Camera.main.transform;

    }
    private void Update()
    { 
        if(photonView.IsMine)
        {
         HandleMovement();

        }
    }

    private void HandleMovement()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        if(xInput==0 && yInput==0 )
        {
            animator.SetBool("move",false);
            return;
        }
        animator.SetBool("move", true);
        //sprint check
        sprinting = Input.GetButton("Sprint");

        Vector3 moveDirection =new Vector3(xInput,0,yInput)* (sprinting?1.5f:1f);

         
        animator.SetFloat(stateVelocityAnimation, moveDirection.magnitude);

        animator.SetFloat(stateDirecitonAnimation, xInput);
        
        Vector3 targetPosition = rb.position + transform.TransformDirection(moveDirection) * speed * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);;
    }
    
    

}
