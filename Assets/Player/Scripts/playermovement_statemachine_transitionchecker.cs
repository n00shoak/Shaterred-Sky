using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement_statemachine_transitionchecker : MonoBehaviour
{
    [SerializeField] private Animator blackBoard ;
    [SerializeField] private InputActionReference move,sprint, mvmActionB, mvmActionA;
    [SerializeField] float groundDist;
    private int jumpleft;
    private DT_PlayerStats stats;


    private void Awake()
    {
        blackBoard = GetComponent<Animator>();
        stats = GetComponent<DT_PlayerStats>();
    }

    private void OnEnable()
    {
        move.action.started += MoveStart;
        move.action.canceled += MoveEnd;

        sprint.action.started += srpintStart;
        sprint.action.canceled += sprintEnd;

        mvmActionB.action.started += MvmActionBStart;
        mvmActionB.action.canceled += MvmActionBEnd;

        mvmActionA.action.started += MvmActionAStart;
        mvmActionA.action.canceled += MvmActionAEnd;
    }


    // Set Move State
    public void MoveStart(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("Moving", true);
    }
    public void MoveEnd(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("Moving", false);
    }


    // set sorint state
    public void srpintStart(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("Sprinting", true);
    }
    public void sprintEnd(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("Sprinting", false);
    }


    // Set mvmActionA State
    public void MvmActionAStart(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("mvmActionA", true);
    }
    public void MvmActionAEnd(InputAction.CallbackContext obj)
    {
        blackBoard.SetBool("mvmActionA", false);
    }


    // Set mvmActionB State
    public void MvmActionBStart(InputAction.CallbackContext obj)
    {
        
        if (blackBoard.GetInteger("MovementType") == 1)
        {
            if( jumpleft > 0)
            {
                jumpleft--;
                blackBoard.SetTrigger("Jump");
            }
        }
        else
        {
            blackBoard.SetBool("mvmActionB", true);
        }

    }
    public void MvmActionBEnd(InputAction.CallbackContext obj)
    {
            blackBoard.SetBool("mvmActionB", false);
    }


    void CheckGround()
    {
        // Crée le ray
        Ray ray = new Ray(transform.position, Vector3.down);

        // Effectue le raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, groundDist))
        {
            blackBoard.SetBool("Grounded", true);
            jumpleft = stats.maxJump;
        }
        else
        {
            blackBoard.SetBool("Grounded", false);
        }
    }

    private void Update()
    {
        CheckGround();
    }

    void OnDrawGizmos()
    {
        // Crée le ray
        Ray ray = new Ray(transform.position, Vector3.down);

        // Effectue le raycast pour déterminer la couleur du gizmo
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, groundDist))
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        // Dessine le gizmo ray
        Gizmos.DrawRay(ray.origin, ray.direction * groundDist);
    }

}

