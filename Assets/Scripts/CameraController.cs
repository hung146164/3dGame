using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThirdPerspectiveController : MonoBehaviour
{
    public PhotonView photonView;
    public Transform player;
    public float rotationSpeed = 1.0f;
    public float minYAngle = -20f; // Minimum vertical angle
    public float maxYAngle = 60f;  // Maximum vertical angle
    public float zoomSpeed = 2.0f; // Speed of zooming in/out
    public float minZoom = 2.0f;   // Minimum distance from the player
    public float maxZoom = 10.0f;  // Maximum distance from the player

    private float currentZoom = 5.0f;  // Current zoom level
    private float currentXRotation = 0.0f;


    private Quaternion targetRotation;
    private void Start()
    {
     
    }
    private void Update()
    {
        if(photonView.IsMine)
        {
            HandleZoom();
            HandleCameraMovement();
        }
        

    }

    private void HandleCameraMovement()
    {
        if (!Input.GetKey(KeyCode.C))
        {
            Vector3 cameraForward = transform.forward;
            cameraForward.y = 0;
            targetRotation= Quaternion.LookRotation(cameraForward);
            player.rotation = Quaternion.Slerp(player.rotation,targetRotation,Time.deltaTime* rotationSpeed);

            Cursor.lockState = CursorLockMode.None;
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, minYAngle, maxYAngle);

        transform.position = player.position - transform.forward * currentZoom;
        transform.RotateAround(player.position, Vector3.up, mouseX);

        transform.localRotation = Quaternion.Euler(currentXRotation, transform.eulerAngles.y, 0);
        
    }

    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= scroll * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        transform.position = player.position - transform.forward * currentZoom;
    }
}
