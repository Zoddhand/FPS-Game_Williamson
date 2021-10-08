using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 1;
    public float sprintMod = 1.5f;
    public float gravityForce = 1f;
    private float vel = 0;
    public float jumpForce = 50;

    float oriSpeed;
    private void Start()
    {
        oriSpeed = movementSpeed;
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * movementSpeed;
        float v = Input.GetAxis("Vertical") * movementSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            movementSpeed = movementSpeed * sprintMod;
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            movementSpeed = oriSpeed;
        characterController.Move((Camera.main.transform.right * h + Camera.main.transform.forward * v) * Time.deltaTime); // Moves the character based on the camera's rotation.
        Gravity();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
       
    }
    void Gravity()
    {
        if (characterController.isGrounded)
            vel = 0;
        else if (!characterController.isGrounded)
        {
            vel -= gravityForce * Time.deltaTime;
            characterController.Move(new Vector3(0, vel, 0));
        }
    }
    void Jump()
    {
        
        if (characterController.isGrounded)
        {
            characterController.Move(new Vector3(0, vel = jumpForce, 0));//
        }   
    }
}
