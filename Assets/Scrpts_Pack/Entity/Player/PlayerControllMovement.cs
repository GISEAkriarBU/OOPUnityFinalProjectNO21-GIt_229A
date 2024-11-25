using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllMovement : MonoBehaviour //ใช้ควบคุมตัวละครหลัก
{
    public float MoveSpeed = 5f; 
    private Camera mainCamera;

    void Start()
    {
       
        mainCamera = Camera.main;
    }

    void Update()//ควบคุมการเคลื่อนที่แนวตั้งและการ track mouse
    {
       
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, verticalInput * MoveSpeed * Time.deltaTime, 0);
        transform.position += movement;

       
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; 

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
