
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Entity_Health playerHealth;

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Entity_Health>();
        }

        if (playerHealth != null)
        {
            playerHealth.onHealthChanged += UpdateHpText;
            UpdateHpText(playerHealth.currentHp, playerHealth.maxHp); // Initial update
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged -= UpdateHpText;
        }
    }

    private void UpdateHpText(float currentHp, float maxHp)
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHp + " / " + maxHp;
        }
    }
}
