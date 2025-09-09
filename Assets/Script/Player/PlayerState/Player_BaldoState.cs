using UnityEngine;

public class Player_BaldoState : PlayerState
{
    private int baldoDir;
    private float stateTimer; // 상태 유지 시간을 위한 타이머

    public Player_BaldoState(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Enter()
    {
        stateTimer = 0.5f; 
        
        // The player might be idle but holding a direction key.
        // We must ensure the character is facing the correct way.
        if (player.moveInput.x != 0 && player.moveInput.x != player.facingDir)
        {
            player.Flip();
        }

        // Now, player.facingDir is guaranteed to be correct.
        player.skillManager.baldo.UseSkill(player.anim, player.facingDir);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 타이머가 다 되면 Idle 상태로 변경
        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);
        else
            stateTimer -= Time.deltaTime;
    }
}
