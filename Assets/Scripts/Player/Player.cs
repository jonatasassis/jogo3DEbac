using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animPlayer;
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
    public float jumpSpeed = 15f;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * (turnSpeed*750) * Time.deltaTime, 0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = -transform.forward * inputAxisVertical * (-speed*10);

        if (characterController.isGrounded)
        { 
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                vSpeed = jumpSpeed; 
            } 
        }
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        { if (Input.GetKey(keyRun))
            { 
                speedVector *= speedRun;
                animPlayer.speed = speedRun;
            } 
            else
            { 
                animPlayer.speed = 1;
            }
        }
        characterController.Move(speedVector * Time.deltaTime);

        if (inputAxisVertical != 0)
        {
            animPlayer.SetBool("Run", true);
        } 
        else 
        {
            animPlayer.SetBool("Run", false);
        }
    }
}
