using UnityEngine;

public class Enemy_FallState : EnemyState
{
    public Enemy_FallState(Enemy enemy, StateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.linearVelocity.y);

        if (enemy.groundDetected)
            stateMachine.ChangeState(enemy.idleState);
    }
}
