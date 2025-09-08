using UnityEngine;

public class Enemy_Warrior : Enemy
{
    private Entity_Combat combat;

    protected override void Awake()
    {
        base.Awake();
        combat = GetComponent<Entity_Combat>();

        idleState = new Enemy_IdleState(this, stateMachine, "idle");
        moveState = new Enemy_MoveState(this, stateMachine, "move");
        attackState = new Enemy_AttackState(this, stateMachine, "attack");
        battleState = new Enemy_BattleState(this, stateMachine, "move");
        deadState = new Enemy_DeadState(this, stateMachine, "idle");
        
    }

    public void Attack()
    {
        combat.performAttack();
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }
}
