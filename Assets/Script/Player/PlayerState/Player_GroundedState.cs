using UnityEngine;

public class Player_GroundedState : PlayerState
{
    public Player_GroundedState(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0 && player.groundDetected == false)
            stateMachine.ChangeState(player.fallState);
        
            
        if (input.Player.Baldo.WasPerformedThisFrame())
            stateMachine.ChangeState(player.baldoState);

        if (input.Player.Jump.WasPerformedThisFrame())
            stateMachine.ChangeState(player.jumpState);

        if(input.Player.Attack.WasPerformedThisFrame())
            stateMachine.ChangeState(player.basicAttackState);
    }
   
}
