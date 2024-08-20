using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFirstPerspectiveController : MonoBehaviour
{
    public CameraManager cameraManager;

    public float sensitivity = 1f;
    public float limitCameraAngleTop = -90f;
    public float limitCameraAngleDown = 60f;

    private float currentXRotation = 0f;

    private void Update()
    {
        HandleCameraMovement();
    }
    public void HandleCameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity* Time.deltaTime;

        // Xoay nhân vật theo trục Y (xoay ngang)
        transform.parent.Rotate(Vector3.up * mouseX);

        // Xoay camera theo trục X (xoay dọc)
        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, limitCameraAngleTop, limitCameraAngleDown);

        // Áp dụng góc xoay cho camera
        transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
}
