using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonTestScript : MonoBehaviour
{
    public int frameLimit = 60;

    [Header("Player")]
    public CharacterController player;
    public float moveSpeed = 1;
    public float jumpSpeed = 1;
    public float gravityMultiplier = 1;
    public float airbornSpeedChange = 1;

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
            moveDirection = new Vector3(moveValue * moveSpeed, jumpValue * jumpSpeed, 0);
        }
        else //airborn
        {
            moveDirection.x = Mathf.MoveTowards(moveDirection.x, moveValue * moveSpeed, airbornSpeedChange * Time.deltaTime);
        }

        //apply gravity, a = dv/dt
        moveDirection += Physics.gravity * gravityMultiplier * Time.deltaTime;

        //move
        player.Move(moveDirection * Time.deltaTime);
    }
}
