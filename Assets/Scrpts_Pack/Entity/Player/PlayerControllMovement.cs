using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    private Camera mainCamera;

    void Start()
    {
        // Cache the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, verticalInput * moveSpeed * Time.deltaTime, 0);
        transform.position += movement;

        // Rotation to face the mouse
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure z is 0 for 2D calculations

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Offset by 90 degrees for correct orientation

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
