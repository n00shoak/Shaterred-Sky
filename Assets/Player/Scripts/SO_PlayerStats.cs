using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDefaultStats", menuName = "PlayerDefaultStats", order = 0)]
public class SO_PlayerStats : ScriptableObject
{
    public int movementType,maxJump;
    public float Speed,drag;

}
