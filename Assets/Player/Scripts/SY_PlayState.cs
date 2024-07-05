using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SY_PlayState : StateMachineBehaviour
{
    public int onEnter,onUpdate,onExit;
    private SY_PlayerStates mvmScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<SY_PlayerStates>();

        if (mvmScript != null) 
        {
            mvmScript.states[onEnter].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> SY_PlayerStates ");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<SY_PlayerStates>();
        if (mvmScript != null) 
        {
            mvmScript.states[onUpdate].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> SY_PlayerStates ");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mvmScript = GameObject.Find("Player").GetComponent<SY_PlayerStates>();
        if (mvmScript != null)
        {
            mvmScript.states[onExit].Invoke();
        }
        else
        {
            Debug.LogError("SY_PLAYSTATE : script not found >> SY_PlayerStates ");
        }
    }

}
