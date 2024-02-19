using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed = 12f;
    private float gravity = -9.81f * 4;
    private Vector3 yVelocity;
    [SerializeField] private float jumpHeight = 3.0f;
    private KeyCode[] controls = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private KeyCode[] altControls = { KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L};
    private KeyCode[] currentControls;
    [SerializeField] private bool isAltControls = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (isAltControls)
        {
            currentControls = altControls;
            transform.Rotate(0, 180, 0);
        }
        else
        {
            currentControls = controls;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = new Vector3();
        yVelocity = new Vector3(0, yVelocity.y, 0);
        if (controller.isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = 0f;
        }

        if (Input.GetKey(currentControls[0]))
        {
            yVelocity += new Vector3(0, 0, speed);
        }
        if (Input.GetKey(currentControls[1]))
        {
            yVelocity += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(currentControls[3]))
        {
            yVelocity += new Vector3(speed, 0, 0);
        }
        
        

        // Check for jump input regardless of other movement inputs
        if (Input.GetKey(currentControls[2]) && controller.isGrounded)
        {
            yVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        yVelocity.y += gravity * Time.deltaTime;
        yVelocity = transform.TransformDirection(yVelocity);
        controller.Move(yVelocity * Time.deltaTime);
    }
}
