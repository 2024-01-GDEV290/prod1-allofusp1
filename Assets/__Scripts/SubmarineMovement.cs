using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float moveSpeed = 20f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
		transform.position = GlobalVars.subPosition + new Vector3(0, -1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        transform.rotation = Quaternion.Euler(0, 0, 0);
		
        //if Input.GetAxisRaw()
		//Saves the last known position of the sub when it enters a cave, so that when it exits
		//it will spawn outside the cave.
		GlobalVars.subPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
