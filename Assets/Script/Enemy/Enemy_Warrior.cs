using UnityEngine;

public class Enemy_Warrior : Enemy, ICounterable
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
        stunnedState = new Enemy_StunnedState(this, stateMachine, "stunned");
        
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

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.F))
            HandleCounter();
    }
    public void HandleCounter()
    {
        if (canBestunned == false)
            return;

        stateMachine.ChangeState(stunnedState);
    }
}
