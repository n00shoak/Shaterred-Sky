using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DT_PlayerStats : MonoBehaviour
{
    public SO_PlayerStats selectedDefaultStats;

    public int movementType, maxJump , boostLength;
    public float speed, sprintSpeed, drag, boostStrength;

    private void Start()
    {
        movementType = selectedDefaultStats.movementType;
        maxJump = selectedDefaultStats.maxJump;
        speed = selectedDefaultStats.speed;
        sprintSpeed = selectedDefaultStats.sprintSpeed;
        drag = selectedDefaultStats.drag;
        boostLength = selectedDefaultStats.boostLength;
        boostStrength = selectedDefaultStats.boostStrength;

        SetStats();
    }


    private void SetStats()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.drag = drag;
    }
}
