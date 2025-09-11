using UnityEngine;

public class Player_Combat : Entity_Combat
{
    [Header("Counter attack details")]
    [SerializeField] private float counterRecovery = .1f;
    
    public bool CounterAttackPerformed()
    {
        bool hasPerformedCounter = false;
        foreach (var target in GetDetectedColliders())
        {
            ICounterable counterable = target.GetComponent<ICounterable>();

            if(counterable == null)
                continue;//�� �ݺ� �ǳʶٰ� �� �ݺ����� 

            if (counterable.CanBeCountered)
            {
                counterable.HandleCounter();
                hasPerformedCounter = true;
            }
        }
        return hasPerformedCounter;
    }

    public float GetCounterRecoveryDuration() => counterRecovery;
}
