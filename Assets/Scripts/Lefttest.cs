using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lefttest : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 targetPosition = new Vector3(10, 10, 0); // Vị trí mục tiêu để di chuyển đến
    public float moveSpeed = 1.0f; // Tốc độ di chuyển
    float currentAngle = 0;
    float target = 180;
    void Start()

    {
        rb = GetComponent<Rigidbody>();
    }
    Vector3 f=new Vector3(0,0,0);
    Vector3 g = new Vector3(0, 180, 0);

    void FixedUpdate()
    {

        target += 180;
        transform.rotation=Quaternion.Euler(0, Mathf.LerpAngle(transform.eulerAngles.y, target, moveSpeed*Time.deltaTime),0);
    }
}
