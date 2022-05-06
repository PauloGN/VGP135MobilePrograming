using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private new Rigidbody rigidbody = null;

    private Camera mainCamera;
    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerScreenBoundary();
        RotateToFaceDirection();
    }

    private void FixedUpdate()
    {
        ProcessInput();

        if (movementDirection == Vector3.zero)
        {
            return;
        }
     

        rigidbody.AddForce(movementDirection * forceMagnitude, ForceMode.Force);

        //Setting a limit of maximum speed to be applied by the force mode
        rigidbody.velocity =  Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);

    }


    private void ProcessInput()
    {
        //checks if the screen was touched
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            //gets the touch position wicth is a vector 2
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            //Converts the touch position from the pixel units of the screen to world position (Unity Cartesian plane)
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

            //getting a new vector pointing the direction that the spaceship shoul move to
            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0.0f;
            movementDirection.Normalize();
           

        }
        else
        {
            movementDirection = Vector3.zero;
           // Debug.Log("No inputs");
        }

    }

    private void  PlayerScreenBoundary()
    {
        //keep on track of player's position;
        Vector3 newPosition = transform.position;

        //Gets the player's position on  the viewport screen independently of the device rate
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        float offSet = 0.1f;
        //Right Side x > 1
        if(viewPortPosition.x > 1.0f)
        {
            newPosition.x = -newPosition.x + offSet;
            
        }
        //Left Side x<0;
        else if(viewPortPosition.x < 0.0f)
        {
            newPosition.x = -newPosition.x - offSet;
        }

        //Up y > 1;
        if (viewPortPosition.y > 1)
        {
            newPosition.y = -newPosition.y + offSet;
        }
        //Down y < 0;
        else if (viewPortPosition.y < 0)
        {
            newPosition.y = -newPosition.y - offSet;
        }

        transform.position = newPosition;
    }


    private void RotateToFaceDirection()
    {
       if(rigidbody.velocity == Vector3.zero)
        {
            return;
        }
        //Gets the rotation based on the direction and y axis (Vector.back considered the one going out of the screen)
        Quaternion targetRotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
