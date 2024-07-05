using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SY_PlayState : StateMachineBehaviour
{
    public int onEnter,onUpdate,onExit;
    private playermovement_statemachine_stateAction mvmScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<playermovement_statemachine_stateAction>();

        if (mvmScript != null)
        {
            mvmScript.states[onEnter].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> playermovement_statemachine_stateAction ");
        }

        mvmScript.HorizontalMovement();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<playermovement_statemachine_stateAction>();
        if (mvmScript != null) 
        {
            mvmScript.states[onUpdate].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> playermovement_statemachine_stateAction ");
        }

        mvmScript.HorizontalMovement();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<playermovement_statemachine_stateAction>();
        if (mvmScript != null)
        {
            mvmScript.states[onExit].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> playermovement_statemachine_stateAction ");
        }

        mvmScript.HorizontalMovement();
    }

}
