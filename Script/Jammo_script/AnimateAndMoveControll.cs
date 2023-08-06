using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class AnimateAndMoveControll : MonoBehaviour
{
    //---------------------------character controll--------------------
    PlayerInput playerinput;
    CharacterController charactercontroller; //-------------------------------modify character controll---------------------
    Animator animator;
    public float gravity = -20f;
    //Rigidbody rb;//-------------------------------------------------------modify rigidbody

    Vector2 CurrentMoveInput;
    Vector3 CurrentMove;
    public Vector3 velocity;
    bool isMovePressed;
    float rotationFactorPerFrame = 1.0f;

    //---------------------------pickup item--------------------


    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        charactercontroller = GetComponent<CharacterController>();//-------------------------------modify character controll---------------------
        animator = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();//-------------------------------------------------------modify rigidbody

        playerinput.CharacterControll.Move.started += onMoveInput;
        playerinput.CharacterControll.Move.canceled += onMoveInput;
        playerinput.CharacterControll.Move.performed += onMoveInput;
    }
    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = CurrentMove.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = CurrentMove.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovePressed )
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame);
        }


    }
    void onMoveInput(InputAction.CallbackContext context)
    {
        CurrentMoveInput = context.ReadValue<Vector2>(); 
        //Debug.Log(CurrentMoveInput);
        CurrentMove.x = CurrentMoveInput.x;
        CurrentMove.z = CurrentMoveInput.y;
        isMovePressed = CurrentMoveInput.x != 0 || CurrentMoveInput.y != 0;
    }
    void handleAnimator()
    {
        //bool isRunning = animator.GetBool("IsRunning");
        if (isMovePressed) { 
            animator.SetBool("IsRunning", true);
        }
        else { 
            animator.SetBool("IsRunning", false); 
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            TryPickupItem();
        }

        handleRotation();
        handleAnimator();
        CurrentMove.y += gravity * Time.deltaTime;
        if (charactercontroller.isGrounded && CurrentMove.y < 0)
        {
            CurrentMove.y = -1.0f;
        }
        velocity = CurrentMove;
        charactercontroller.Move(CurrentMove * Time.deltaTime * 5);//-------------------------------modify character controll---------------------
        //rb.MovePosition(transform.position + CurrentMove * Time.deltaTime * 15);//-------------------------------------------------------modify rigidbody

    }
    void OnEnable()
    {
        playerinput.CharacterControll.Enable();
    }
    void OnDisable()
    {
        playerinput.CharacterControll.Disable();
    }
    private void TryPickupItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // Adjust the radius as needed
        Item nearestItem = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            Item itemPickup = collider.GetComponent<Item>();
            if (itemPickup != null)
            {
                float distance = Vector3.Distance(transform.position, itemPickup.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestItem = itemPickup;
                }
            }
        }

        if (nearestItem != null)
        {
            //nearestItem.PickupItem();
            Destroy(nearestItem.gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        //Gizmos.DrawWireSphere(transform.position , 1f);
    }
}
