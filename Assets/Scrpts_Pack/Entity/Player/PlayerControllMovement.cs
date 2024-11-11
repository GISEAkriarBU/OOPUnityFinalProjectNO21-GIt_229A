using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the spaceship
    public float rotationSpeed = 200f; // Speed at which the spaceship rotates to face the mouse

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        MoveShip();
        RotateShipTowardsMouse();
    }

    void MoveShip()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a movement vector based on input and moveSpeed
        Vector2 movement = new Vector2(horizontal, vertical).normalized * moveSpeed * Time.deltaTime;

        // Move the spaceship
        transform.Translate(movement, Space.World);
    }

    void RotateShipTowardsMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure we only deal with 2D coordinates

        // Calculate the direction from the spaceship to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle in degrees and rotate the spaceship
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Rotate the spaceship smoothly
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
