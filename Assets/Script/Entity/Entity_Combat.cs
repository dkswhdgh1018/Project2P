using UnityEngine;

public class Entity_Combat : MonoBehaviour
{
    [Header("Combat details")]
    [SerializeField] public float damage = 10;

    [Header("Target detection")]
    [SerializeField] private Transform targetCheck;
    [SerializeField] private float targetCheckRadius = 1;
    [SerializeField] private LayerMask whatIsTarget;


    

    public void performAttack()
    {
        foreach (var target in GetDetectedColliders())
        {
            Entity_Health targetHealth = target.GetComponent<Entity_Health>();

            targetHealth?.TakeDamage(damage, transform);
            targetHealth?.GetEntityVfx();
        }
    }


    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(targetCheck.position, targetCheckRadius, whatIsTarget);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetCheck.position, targetCheckRadius);
    }
}
