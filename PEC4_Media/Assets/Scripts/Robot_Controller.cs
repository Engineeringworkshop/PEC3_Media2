using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Controller : MonoBehaviour
{
    public float moveInput;
    private Vector3 movement;
    public float movementSpeed;

    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode attackKey;
    public KeyCode defenseKey;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check player inputs
        CheckInputs();

        // Calculate movement vector 
        CalculateMovement();
    }

    private void FixedUpdate()
    {
        // Move character
        MoveCharacter(movement);
    }

    private void CheckInputs()
    {
        // Left movement control
        if (Input.GetKeyDown(moveLeftKey))
        {
            print("Left key pushed by " + name);

            moveInput = 1;
        }
        else if (Input.GetKeyUp(moveLeftKey))
        {
            print("Left key released by " + name);

            moveInput = 0;
        }

        // Right movement control
        if (Input.GetKeyDown(moveRightKey))
        {
            print("Right key pushed by " + name);

            moveInput = -1;
        }
        else if (Input.GetKeyUp(moveRightKey))
        {
            print("Right key released by " + name);

            moveInput = 0;
        }


        // Attack control
        if (Input.GetKeyDown(attackKey))
        {
            print("Attack key pushed by " + name);
        }

        // Defense control
        if (Input.GetKeyDown(defenseKey))
        {
            print("Defense key pushed  by " + name);
        }

        print("Move input: " + moveInput);
    }

    private void CalculateMovement()
    {
        movement = new Vector3(0, 0, moveInput).normalized;
    }

    private void MoveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        rb.velocity = - direction * movementSpeed * Time.fixedDeltaTime;
    }
}
