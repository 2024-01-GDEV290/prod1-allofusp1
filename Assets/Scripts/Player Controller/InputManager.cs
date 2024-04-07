using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerInput.DialogueActions dialogue;
    private PlayerMotor motor;
    public static InputManager S;


    // Start is called before the first frame update
    void Awake()
    {
        S = this;
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        dialogue = playerInput.Dialogue;
        
        // Player Movement
        motor = GetComponent<PlayerMotor>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.ResetScene.performed += ctx => motor.ResetScene();

        // Advance and reverse time
        onFoot.AdvanceTime.performed += ctx => motor.AdvanceTime(ctx);
        onFoot.AdvanceTime.canceled += ctx => motor.AdvanceTime(ctx);
        onFoot.ReverseTime.performed += ctx => motor.ReverseTime(ctx);
        onFoot.ReverseTime.canceled += ctx => motor.ReverseTime(ctx);

        // Interact with Items or NPCs
        onFoot.Interact.performed += ctx => motor.Interact();

        // Advance dialogue
        dialogue.NextLine.performed += ctx => motor.NextLine();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void SetOnFoot()
    {
        onFoot.Enable();
        dialogue.Disable();
    }

    public void SetDialogue()
    {
        dialogue.Enable();
        onFoot.Disable();

    }
    // Update is called once per frame
    void Update()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        motor.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
