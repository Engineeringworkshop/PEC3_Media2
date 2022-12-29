using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Robot_Controller : MonoBehaviour
{
    public float moveInput;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.currentActionMap = "Player1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();

        Debug.Log("Movement: " + moveInput + " name: " + this.name);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack: name: " + this.name);
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack: name: " + this.name);
        }
    }
}
