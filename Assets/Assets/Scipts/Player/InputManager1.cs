using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager1 : MonoBehaviour
{
    private Vector2 moveDir=Vector2.zero;
    private bool jumpPressed=false;

    private bool submitPressed=false;

    public static InputManager1 instance{get;private set;}

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one InputManager ");
        }
        instance=this;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            moveDir=context.ReadValue<Vector2>();
        }
        else if(context.canceled)
        {
            moveDir=context.ReadValue<Vector2>();
        }
    }
    public void JumpPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            jumpPressed=true;
        }
        else if(context.canceled)
        {
            jumpPressed=false;
        }
    }
    public Vector2 GetMoveDirection()
    {
        return moveDir;
    }
    public bool GetJumpPressed()
    {
        bool result=jumpPressed;
        jumpPressed=false;
        return result;
    }
}
