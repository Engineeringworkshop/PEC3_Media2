using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Controller : MonoBehaviour
{
    public float moveInput;
    public string mapName;

    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode attackKey;
    public KeyCode defenseKey;

    void Update()
    {
        CheckInputs();
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

}
