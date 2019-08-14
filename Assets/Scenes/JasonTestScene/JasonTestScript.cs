using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasonTestScript : MonoBehaviour
{
    public int frameLimit = 60;
    public Rigidbody player;
    public float playerMoveSpeed = 1;
    public float playerJumpSpeed = 1;

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
        if (player == null)
            return;

        float moveValue = Input.GetAxis("Horizontal");
        float jumpValue = Input.GetKeyDown(KeyCode.Space) ? 1 : 0;
        Vector3 velocity = player.velocity;
        velocity.x = moveValue * playerMoveSpeed;
        if (jumpValue != 0)
            velocity.y = jumpValue * playerJumpSpeed;
        player.velocity = velocity;
    }
}
