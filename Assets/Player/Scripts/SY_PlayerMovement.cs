using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SY_PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference Move;
    [SerializeField] private DT_PlayerStats stats;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public UnityEvent[] states;


    private void Awake()
    {
        stats = GetComponent<DT_PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    public void PrintStuff()
    {
        Debug.Log("Stuff");
    }

    public void HorizontalMovement()
    {
        Vector2 dir = Move.action.ReadValue<Vector2>();
        rb.AddForce(new Vector3(dir.x, 0, dir.y) * stats.speed);
    }


}
