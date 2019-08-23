using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonTestScript : MonoBehaviour
{
    public int frameLimit = 60;
    public CharacterController player;
    public float playerMoveSpeed = 1;
    public float playerJumpSpeed = 1;
    private Vector3 moveDirection = Vector3.zero;

    public void OnEnable()
    {
        Application.targetFrameRate = frameLimit;
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        //https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
        if (player == null)
            return;

        float moveValue = Input.GetAxis("Horizontal");
        float jumpValue = Input.GetButtonDown("Jump") ? 1 : 0;

        if (player.isGrounded)
        {
            moveDirection = new Vector3(moveValue * playerMoveSpeed, jumpValue * playerJumpSpeed, 0);
        }

        //apply gravity, a = dv/dt
        moveDirection += Physics.gravity * Time.deltaTime;

        //move
        player.Move(moveDirection * Time.deltaTime);
    }
}
