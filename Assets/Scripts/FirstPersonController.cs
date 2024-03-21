using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonController : MonoBehaviour
{

    //some code credit to Kevin

    public float speed = 5.0f;
    public float sensitivity = 2.0f;
    private float moveFB, moveLR;
    private float rotX, rotY;
    public float sprintSpeedMultiplier = 2.0f; // Multiplier for speed when sprinting
    public float jumpForce = 1.0f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject camera;
    private Rigidbody rb;
    
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }
        
        

    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {

            moveFB *= sprintSpeedMultiplier;
            moveLR *= sprintSpeedMultiplier;
        }

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -89f, 89f);

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);
        camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        transform.position += movement * Time.deltaTime;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Checks if you're on the ground

        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        

        

        // Applying movement separately to respect Rigidbody's physics
        //rb.MovePosition(rb.position + movement * Time.deltaTime);
    }
}
