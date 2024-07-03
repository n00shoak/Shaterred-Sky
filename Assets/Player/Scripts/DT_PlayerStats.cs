using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DT_PlayerStats : MonoBehaviour
{
    public SO_PlayerStats selectedDefaultStats;

    public int movementType, maxJump;
    public float speed, drag;

    private void Start()
    {
        movementType = selectedDefaultStats.movementType;
        maxJump = selectedDefaultStats.maxJump;
        speed = selectedDefaultStats.Speed;
        drag = selectedDefaultStats.drag;
    }

   
}
