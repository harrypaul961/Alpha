using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private CharacterController controller;
    private Animator anim;

    private bool isMoving;

    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 direction;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
         MovementCheck();
         AnimationCheck();
    }

     private void MovementCheck()
     {
       horizontalMovement = Input.GetAxisRaw("Horizontal");
       verticalMovement = Input.GetAxisRaw("Vertical");

       direction = new Vector3(horizontalMovement, 0, verticalMovement);

      if(direction.magnitude >= 0.1f)
      {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) *Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        controller.Move(direction * speed * Time.deltaTime);
        
      }


     }
     
     private void AnimationCheck()

     {
       if(direction != Vector3.zero && !isMoving)
      {
  
        isMoving = true;
        anim.SetBool("isRunning", isMoving);
       }
       else if(direction == Vector3.zero && isMoving)
       {

        isMoving = false;
        anim.SetBool("isRunning", isMoving);

       }


     }

}
