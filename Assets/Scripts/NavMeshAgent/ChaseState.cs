

using UnityEngine;

public class ChaseState : IState
{
    private AIController aiController;

    private Animator animator;
    //private Transform target;
    
    public ChaseState(AIController aiController, Animator animator)
    {
        this.aiController = aiController;
        this.animator = animator;
    }
    
    public void Enter()
    {
        Debug.Log("Animation: Chasing");
    }

    public void Execute()
    {
        //Chase the player
        aiController.SetDestination(aiController.target.position);
        
    }

    public void Exit()
    {
        
    }
}
