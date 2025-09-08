using UnityEngine;

public class Enemy : Entity
{

    public Enemy_IdleState idleState;
    public Enemy_MoveState moveState;
    public Enemy_AttackState attackState;
    public Enemy_BattleState battleState;
    public Enemy_DeadState deadState;
    

    [Header("Battle details")]
    public float battleMoveSpeed = 3;
    public float attackDistance = 2;
    public float battleTimeDuration = 5;
    public float minRetreatDistance = 1;
    public Vector2 retreatVelocity;
    

    [Header("Movement Details")]
    public float idleTime = 2;
    public float moveSpeed = 1.4f;
    [Range(0, 2)]
    public float moveAnimMoveSpeedMultiplier = 1;

    [Header("Facing direction")]
    [SerializeField] private bool startFacingLeft;

    [Header("Player detection")]
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float playerCheckDistance = 10;
    [SerializeField] private float playerCheckDistanceBackward = 5;

    public Transform player { get; private set; }

    public override void onEntityDeath()
    {
        base.onEntityDeath();

        stateMachine.ChangeState(deadState);
    }

    public void TryEnterBattleState(Transform player)
    {
        if (stateMachine.currentState == battleState)
            return;

        if(stateMachine.currentState == attackState)
            return;

        this.player = player; 
        stateMachine.ChangeState(battleState);
    }

    public Transform GetPlayerReference()
    {
        if (player == null)
            player = PlayerDetected().transform;
        
        
        return player;
    }
   

    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, playerCheckDistance, whatIsPlayer);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            return hit;

        hit = Physics2D.Raycast(playerCheck.position, Vector2.right * -facingDir, playerCheckDistanceBackward, whatIsPlayer);
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            return hit;

        return default;
    }

    protected override void Start()
    {
        base.Start();

        if (startFacingLeft)
        {
            Flip();
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (playerCheckDistance * facingDir), playerCheck.position.y));
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x - (playerCheckDistanceBackward * facingDir), playerCheck.position.y));
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (facingDir * attackDistance), playerCheck.position.y));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + (facingDir * minRetreatDistance), playerCheck.position.y));
    }
}
