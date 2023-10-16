using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;
//using System.Numerics;

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

    //---------------------------Nav mesh agent--------------------
    NavMeshAgent agent;
    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;
    //float lookRotationSpeed = 1000f;
    public Camera playerCamera;

    //-----------------------------attack------------------------
    [Header("Attack")]
    [SerializeField] float attackSpeed = 1.5f;
    [SerializeField] float attackDelay = 0.3f;
    [SerializeField] float attackDistance = 1.5f;
    [SerializeField] int attackDamage = 1;
    [SerializeField] ParticleSystem hitEffect;
    // eiei
    bool playerBusy = false;
    Interactable target;
    bool IsStop = false;
    [SerializeField]  bool Canhit = false;


    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        charactercontroller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        playerinput.CharacterControll.Move.started += onMoveInput;
        playerinput.CharacterControll.Move.canceled += onMoveInput;
        playerinput.CharacterControll.Move.performed += onMoveInput;

        playerinput.CharacterControll.MouseMove.performed += Click2Move;

    }
    void Click2Move(InputAction.CallbackContext context)
    {
        RaycastHit hit;

        //if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100, clickableLayers))
        if (Physics.Raycast(playerCamera.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100, clickableLayers))
        {
            //agent.destination = hit.point;
            //FaceTarget();


            //agent.SetDestination(hit.point);
            //if (clickEffect != null)
            //{
            //    Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
            //}
            IsStop = false;

            if (hit.transform.CompareTag("Enemy"))
            {
                target = hit.transform.GetComponent<Interactable>();
                //if (clickEffect != null)
                //{ Instantiate(hitEffect, hit.transform.position + new Vector3(0, 0.5f, 0), hitEffect.transform.rotation); }
            }
            else
            {
                target = null;

                agent.SetDestination(hit.point);
                if (clickEffect != null)
                { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
            }
        }
}
    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = CurrentMove.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = CurrentMove.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovePressed)
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
        target = null;
    }
    void handleAnimator()
    {
        //bool isRunning = animator.GetBool("IsRunning");
        //if (isMovePressed) 
        if (agent.velocity != Vector3.zero | isMovePressed)
        { 
            animator.SetBool("IsRunning", true);
        }
        else { 
            animator.SetBool("IsRunning", false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.B))  //stop 
        { 
            IsStop = true;
            agent.SetDestination(transform.position);
            ResetBusyState();
        }
        FollowTarget();

        //if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        //{
        //    TryPickupItem();
        //}

        handleAnimator();
        //FaceTarget();

        CurrentMove.y += gravity * Time.deltaTime;
        if (charactercontroller.isGrounded && CurrentMove.y < 0)
        {
            CurrentMove.y = -1.0f;
        }
        //velocity = CurrentMove;
        if (isMovePressed)
        {
            charactercontroller.Move(CurrentMove * Time.deltaTime * 5);
            handleRotation();
            agent.SetDestination(transform.position);
        }
    }
    //--------------------------------------------------------------------------------attack function----------------------------------------------------------------
    void FollowTarget()
    {

        if (target == null | IsStop)
        {
            target = null;
            return;
        }

        RaycastHit hit_target;
        Vector3 ray_origin = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Vector3 ray_target = new Vector3(target.transform.position.x, 0.5f, target.transform.position.z);
        Debug.DrawLine(ray_origin, ray_target, Color.red);
        if (Physics.Raycast(ray_origin, ray_target - ray_origin, out hit_target))
        {
            Debug.DrawLine(ray_origin, hit_target.point, Color.blue);
            if (hit_target.transform.CompareTag("Enemy")){ Canhit = true; }
            else { Canhit = false; }
        }
        if (Vector3.Distance(target.transform.position, transform.position) <= attackDistance && Canhit)
        {
            ReachDistance();
        }
        else
        { agent.SetDestination(target.transform.position); Canhit = false; }
    }
    void ReachDistance()
    {
        agent.SetDestination(transform.position);
        if (playerBusy) return;

        playerBusy = true;

        switch (target.interactionType)
        {
            case InteractableType.Enemy:
                //animator.Play("Attack1");
                animator.SetTrigger("Attack1");
                //animator.SetBool("Attack1", true);

                Invoke(nameof(SendAttack), attackDelay);
                Invoke(nameof(ResetBusyState), attackSpeed);
                break;
            //case InteractableType.Item:

                //    animator.Play("GatheringItem");
                //    target.InteractWithItem();
                //    target = null;

                //    Invoke(nameof(ResetBusyState), 0.5f);
                //    break;
        }
        //Invoke(nameof(ResetBusyState), attackSpeed);
    }
    void SendAttack()
    {
        if (target == null) return;

        if (target.myActor.health <= 0)
        { target = null; return; }

        Instantiate(hitEffect, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        target.GetComponent<AttributesManager>().TakeDamage(attackDamage);
    }

    void ResetBusyState()
    {
        playerBusy = false;
        SetAnimations();
    }
    void SetAnimations()
    {
        if (playerBusy) return;
        if (!(agent.velocity != Vector3.zero | isMovePressed)){ animator.Play("HumanoidDefault"); }
        //if (agent.velocity == Vector3.zero)
        //{ animator.Play("HumanoidDefault"); }
        //else
        //{ animator.Play("Run"); }
    }
    //--------------------------------------------------------------------------------attack script end----------------------------------------------------------------

    void OnEnable()
    {
        //playerinput.CharacterControll.Enable();
        playerinput.Enable();
    }
    void OnDisable()
    {
        //playerinput.CharacterControll.Disable();
        playerinput.Disable();
    }
    //private void TryPickupItem()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); // Adjust the radius as needed
    //    Item nearestItem = null;
    //    float nearestDistance = Mathf.Infinity;

    //    foreach (Collider collider in colliders)
    //    {
    //        Item itemPickup = collider.GetComponent<Item>();
    //        if (itemPickup != null)
    //        {
    //            float distance = Vector3.Distance(transform.position, itemPickup.transform.position);
    //            if (distance < nearestDistance)
    //            {
    //                nearestDistance = distance;
    //                nearestItem = itemPickup;
    //            }
    //        }
    //    }

    //    if (nearestItem != null)
    //    {
    //        //nearestItem.PickupItem();
    //        Destroy(nearestItem.gameObject);
    //    }
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
    //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        //Gizmos.DrawWireSphere(transform.position , 1f);
    }
}
