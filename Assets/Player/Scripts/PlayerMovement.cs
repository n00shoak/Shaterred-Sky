using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator blackBoard ;
    [SerializeField] private InputActionReference Jump,move;
    [SerializeField] int jumpleft, maxJump;
    [SerializeField] float groundDist;


    private void Awake()
    {
        blackBoard = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        Jump.action.started += JumpStart;
        Jump.action.canceled += JumpEnd;

        move.action.started += MoveStart;
        move.action.canceled += MoveEnd;
    }


    // Set Jump State
    public void JumpStart(InputAction.CallbackContext obj)
    {
        if (jumpleft > 0)
        {
            jumpleft--;
            blackBoard.SetBool("Jump", true);
        }
    }
    public void JumpEnd(InputAction.CallbackContext obj)
    {
            blackBoard.SetBool("Jump", false);
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


    void CheckGround()
    {
        // Crée le ray
        Ray ray = new Ray(transform.position, Vector3.down);

        // Effectue le raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, groundDist))
        {
            blackBoard.SetBool("Grounded", true);
            jumpleft = maxJump;
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

