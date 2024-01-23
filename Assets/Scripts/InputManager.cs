using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerControls controls;

    public static Vector2 movementInput;
    public static Vector2 turnInput;
    public static bool isAimingInput = false;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.Player.Move.performed += Move;
        controls.Player.Move.canceled += Move;

        controls.Player.Turn.performed += Turn;
        controls.Player.Turn.canceled += Turn;

        controls.Player.Aiming.performed += ctx => isAimingInput = true;
        controls.Player.Aiming.canceled += ctx => isAimingInput = false;

        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= Move;
        controls.Player.Move.canceled -= Move;

        controls.Player.Turn.performed -= Turn;
        controls.Player.Turn.canceled -= Turn;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        Debug.Log("Movement input performed " + movementInput);
    }

    private void Turn(InputAction.CallbackContext ctx)
    {
        turnInput = ctx.ReadValue<Vector2>();
    }

}
