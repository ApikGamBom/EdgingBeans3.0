using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SpacePlayerMov : MonoBehaviour
{

    #region Variables

    [Header("Movement")]
    public Transform playerPosition;
    public CharacterController controller;
    public float speed = 4f;
    public float sprint = 1.5f;

    [Header("Dashing")]
    public Camera Camera;
    public float w_time = 0;
    public float a_time = 0;
    public float s_time = 0;
    public float d_time = 0;

    [Header("Gravity")]
    public float gravity = -3f * 2f;
    public float jumpHeight = 1.5f;
    public bool continousJump = true;
    public float inAirResistance = 0.6f;

    [Header("GroundChecks")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    bool isGrounded;

    #endregion

    Vector3 velocity;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        #region Basic Movement with sprint

        if (Input.GetKey(KeyCode.LeftShift)) //detects for shift key pressed
        {
            if (isGrounded)
            {
                controller.Move(move * speed * Time.deltaTime * sprint); //if shift pressed this happens (player moves 1.4 as fast)
                //Debug.Log("Sprinting!");
            } else
            {
                controller.Move(move * speed * inAirResistance * Time.deltaTime * sprint); //if shift pressed this happens (player moves 1.4 as fast)
                //Debug.Log("Sprinting in air!");
            }
        } else {
            if (isGrounded)
            {
                controller.Move(move * speed * Time.deltaTime); //if shift not is pressed this happens (plyer moves at default speed wich is in the <speed> variable)
                //Debug.Log("Walking normal!")
            } else
            {
                controller.Move(move * speed * inAirResistance * Time.deltaTime); //if shift not is pressed this happens (plyer moves at default speed wich is in the <speed> variable)
                //Debug.Log("Walking in air!")
            }
        }

        #endregion

        #region wasd input timer

        if (Input.GetKey(KeyCode.W))
        {
            w_time += 1;
        } else
        {
            w_time = 0;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            a_time += 1;
        } else
        {
            a_time = 0;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            s_time += 1;
        } else
        {
            s_time = 0;
        }
        
        if((Input.GetKey(KeyCode.D)))
        {
            d_time += 1;
        } else
        {
            d_time = 0;
        }

        #endregion

        //Dashing
        if(Input.GetKeyDown(KeyCode.V))
        {
            controller.Move(move * 2);
            Debug.Log("Dashed!");
        }

        #region Jumping

        if (continousJump)
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                //Debug.Log("Jumping continous!");
        } else {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                //Debug.Log("Jumping noncontinous!");
            }
        }

        #endregion

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Pressed R!");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
