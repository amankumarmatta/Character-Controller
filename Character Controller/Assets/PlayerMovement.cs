using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 12f;
  public CharacterController controller;

  Vector3 velocity;
  public float gravity = -9.81f;
  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;
  bool isGrounded;
  void Update()
  {
    MovePlayer();
  }
    
  void MovePlayer()
  {
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0)
    {
      velocity.y = -2f;
    }

    if(Input.GetButton("Jump") && isGrounded)
    {
      velocity.y = Mathf.Sqrt(-2f * gravity * 3f); // initial velocity formula to reach a certain height
    }

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;
    controller.Move(move * speed * Time.deltaTime);

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);   //delta y = 1/2 * g * t^2 (kinematic equation used to calculate the vertical distance an object travels during free fall)
    
  }
}
