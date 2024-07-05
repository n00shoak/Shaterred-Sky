using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SY_PlayerStates : MonoBehaviour
{
    [SerializeField] private InputActionReference Move;
    [SerializeField] public UnityEvent[] states;

    private DT_PlayerStats stats;
    private Rigidbody rb;

    private int boost = 50;


    private void Awake()
    {
        stats = GetComponent<DT_PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        boost = stats.boostLength;
    }

    public void nothing()
    {

    }

    public void HorizontalMovement()
    {
        Vector2 dir = Move.action.ReadValue<Vector2>();
        rb.AddForce(new Vector3(dir.x, 0, dir.y) * stats.speed);
        Debug.Log(stats.speed);
    }

    public void Sprint()
    {
        Vector2 dir = Move.action.ReadValue<Vector2>();
        rb.AddForce(new Vector3(dir.x, 0, dir.y) * (stats.sprintSpeed ));
    }

    public void Boost()
    {
        Debug.Log("Boosting");

        if (boost == stats.boostLength)
        {
            StartCoroutine(Boosting());
        }
    }

    private IEnumerator Boosting()
    {

        rb.AddForce(transform.forward * stats.boostStrength);
        yield return new WaitForEndOfFrame();
        if (boost > 0) {boost --; StartCoroutine(Boosting()); }
        else { boost = stats.boostLength; }

    }

}
