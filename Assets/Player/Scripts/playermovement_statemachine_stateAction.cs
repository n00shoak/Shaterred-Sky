using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class playermovement_statemachine_stateAction : MonoBehaviour
{
    [SerializeField] private InputActionReference Move;
    [SerializeField] private DT_PlayerStats stats;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public UnityEvent[] states;
    private int boost;
    private float speed;


    private void Awake()
    {
        stats = GetComponent<DT_PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    public void nothing()
    {

    }

    public void HorizontalMovement()
    {
        Vector2 dir = Move.action.ReadValue<Vector2>();
        rb.AddForce(new Vector3(dir.x, 0, dir.y) * stats.speed);
    }

    public void Sprint()
    {
        Vector2 dir = Move.action.ReadValue<Vector2>();
        rb.AddForce(new Vector3(dir.x, 0, dir.y) * (stats.speed * 2 ));
    }

    public void Boost()
    {
        if(boost == 100)
        {
            StartCoroutine(Boosting());
        }
    }

    private IEnumerator Boosting()
    {

        yield return new WaitForEndOfFrame();
        rb.AddForce(transform.forward * 1f);

        if (boost > 0) { StartCoroutine(Boosting()); }
        else { boost = 100; }

    }

}
